using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    public void changeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Tutorial");
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Game is quitting");
    }
}
