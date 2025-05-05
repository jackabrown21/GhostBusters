using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpecialItem : MonoBehaviour
{
    public enum ItemType { WallDestroyer, QuitGame }
    public ItemType itemType;

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
        else if (itemType == ItemType.WallDestroyer && wallToDestroy != null)
        {
            Debug.Log("Wall item picked up. Destroying wall...");
            Destroy(wallToDestroy);
        }

        Destroy(gameObject); // Optionally destroy the cube after pickup
    }
}
