using UnityEngine;


public class ReturnToHolster : MonoBehaviour
{
    public Transform holsterPoint;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;
    private Rigidbody rb;

    private bool isHeld = false;

    void Awake()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        grab.selectEntered.AddListener(_ =>
        {
            isHeld = true;
            // setColliders(true);
        });
        grab.selectExited.AddListener(_ =>
        {
            isHeld = false;
            // setColliders(false);
            Invoke(nameof(ReturnToHolsterIfNotHeld), 1.0f);
        });
    }

    void ReturnToHolsterIfNotHeld()
    {
        if (!isHeld)
        {
            rb.isKinematic = true;
            transform.SetParent(holsterPoint);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }

    void Update()
    {
        if (!isHeld && transform.parent == holsterPoint)
        {
            rb.isKinematic = true;
        }
    }

    void setColliders(bool enable)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = enable;
        }
    }
}