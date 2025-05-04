using UnityEngine;


public class DetachFromHolsterOnGrab : MonoBehaviour
{
    void Start()
    {
        var grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grab.selectEntered.AddListener(_ =>
        {
            transform.SetParent(null);
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb) rb.isKinematic = false;
        });
    }
}