using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject wallToDestroy; // Assign this in the Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("QuitItem"))
        {
            Debug.Log("Quit item picked up. Quitting game...");
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Only works in the editor
#endif
        }
        else if (other.CompareTag("WallItem"))
        {
            if (wallToDestroy != null)
            {
                Debug.Log("Wall item picked up. Destroying wall...");
                Destroy(wallToDestroy);
            }
        }
    }
}
