using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour
{
    public void Play()
    {
        // Load the scene here and disable the button
        SceneManager.LoadSceneAsync(1);
    }
    public void Settings()
    {
        Debug.Log("Just kidding");
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
