using UnityEngine;

public class DisableCollider : MonoBehaviour
{
    public void DisableAllColliders()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        Debug.Log("Disabling colliders in " + gameObject.name);
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
    }

    public void EnableAllColliders()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        Debug.Log("Enabling colliders in " + gameObject.name);
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;

        }
    }
}
