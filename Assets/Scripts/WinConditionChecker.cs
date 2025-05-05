using UnityEngine;
using TMPro;

public class WinConditionChecker : MonoBehaviour
{
    public GhostRetriever ghostRetriever;     // Assign the vacuum object
    public TextMeshProUGUI winText;           // Assign the WinText object

    private bool hasWon = false;

    void Start()
    {
        if (winText != null)
            winText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!hasWon && ghostRetriever != null && ghostRetriever.GhostCount >= 5)
        {
            hasWon = true;
            winText.gameObject.SetActive(true);
            Debug.Log("🎉 Win condition met: all ghosts collected");
        }
    }
}
