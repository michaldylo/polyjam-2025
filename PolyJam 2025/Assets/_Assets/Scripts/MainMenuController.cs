using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync("Michal");
    }

    public void ShowTutorial()
    {
        SceneManager.LoadSceneAsync("Tutorial");
    }
}
