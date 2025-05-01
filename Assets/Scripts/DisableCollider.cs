using UnityEngine;

public class DisableCollider : MonoBehaviour
{
    public void DisableAllColliders()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
            Debug.Log("Disabled collider: " + collider.name);
        }
    }

    public void EnableAllColliders()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
            Debug.Log("Enabled collider: " + collider.name);
        }
    }
}
