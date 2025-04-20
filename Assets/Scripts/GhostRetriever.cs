using UnityEngine;

using TMPro;

public class GhostRetriever : MonoBehaviour
{
    public Transform suctionPoint;
    public float destroyDistance = 1.0f;

    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;
    [SerializeField] private AudioSource vacuumAudioSource;
    [SerializeField] private AudioClip vacuumSound;
    [SerializeField] private TextMeshPro ghostCounterText;

    private bool isHeld = false;
    private int ghostCount = 0;

    private void Start()
    {
        if (interactable == null)
            interactable = GetComponentInParent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();

        if (interactable != null)
        {
            interactable.selectEntered.AddListener(_ =>
            {
                isHeld = true;
                Debug.Log("[GhostRetriever] Vacuum grabbed");
            });

            interactable.selectExited.AddListener(_ =>
            {
                isHeld = false;
                Debug.Log("[GhostRetriever] Vacuum released");

                if (vacuumAudioSource != null)
                    vacuumAudioSource.Stop();
            });
        }

        if (ghostCounterText != null)
            ghostCounterText.text = "0";
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isHeld) return;

        Transform root = other.transform.root;
        if (!root.CompareTag("Ghost")) return;

        float distance = Vector3.Distance(suctionPoint.position, root.position);
        Debug.Log($"[GhostRetriever] Distance to {root.name}: {distance}");

        if (distance < destroyDistance)
        {
            Debug.Log($"[GhostRetriever] Ghost destroyed: {root.name}");

            if (vacuumAudioSource != null && vacuumSound != null)
            {
                if (!vacuumAudioSource.isPlaying)
                {
                    vacuumAudioSource.clip = vacuumSound;
                    vacuumAudioSource.loop = false;
                    vacuumAudioSource.Play();
                    Invoke(nameof(StopVacuumSound), 2f);
                }
            }

            Destroy(root.gameObject);

            ghostCount++;
            if (ghostCounterText != null)
                ghostCounterText.text = ghostCount.ToString();
        }
    }

    private void StopVacuumSound()
    {
        if (vacuumAudioSource != null && vacuumAudioSource.isPlaying)
        {
            vacuumAudioSource.Stop();
            Debug.Log("[GhostRetriever] Vacuum sound stopped");
        }
    }
}