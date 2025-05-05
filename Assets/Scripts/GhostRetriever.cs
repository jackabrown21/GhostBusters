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
    public int GhostCount => ghostCount;

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

    if (!other.CompareTag("Ghost")) return; // Check the collider you actually hit

    float distance = Vector3.Distance(suctionPoint.position, other.transform.position);
    Debug.Log($"[GhostRetriever] Distance to {other.name}: {distance}");

    if (distance < destroyDistance)
    {
        Debug.Log($"[GhostRetriever] Ghost destroyed: {other.name}");

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

        Destroy(other.gameObject);

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