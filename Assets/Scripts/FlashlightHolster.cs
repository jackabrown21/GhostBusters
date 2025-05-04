using UnityEngine;

public class FlashlightHolster : MonoBehaviour
{
    public Transform flashlight;
    public Transform holsterPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == flashlight && flashlight.parent == null)
        {
            flashlight.SetParent(holsterPosition);
            flashlight.localPosition = Vector3.zero;
            flashlight.localRotation = Quaternion.identity;

            Rigidbody rb = flashlight.GetComponent<Rigidbody>();
            if (rb) rb.isKinematic = true;
        }
    }
}