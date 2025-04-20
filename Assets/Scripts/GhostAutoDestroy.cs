using UnityEngine;

public class GhostAutoDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Ghost"))
        {
            Debug.Log($"[SuctionZone] Destroyed ghost: {other.transform.root.name}");
            Destroy(other.transform.root.gameObject);
        }
    }
}