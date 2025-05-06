using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpecialItem : MonoBehaviour
{
    public enum ItemType { WallDestroyer, QuitGame }
    public ItemType itemType;


    [SerializeField] GameObject[] toDestroy;
    public GameObject wallToDestroy;

    void Start()
    {
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnItemPickedUp);
        }
    }

    private void OnItemPickedUp(SelectEnterEventArgs args)
    {
        if (itemType == ItemType.QuitGame)
        {
            Debug.Log("Quit item picked up. Quitting...");
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        else if (itemType == ItemType.WallDestroyer)
        {
            // Destroy all objects in the toDestroy array
            foreach (GameObject obj in toDestroy)
            {
                if (obj != null)
                {
                    Debug.Log("Destroying object: " + obj.name);
                    // Destroy object and its children
                    Destroy(obj);

                }
            }
        }

        Destroy(gameObject); // Optionally destroy the cube after pickup
    }
}
