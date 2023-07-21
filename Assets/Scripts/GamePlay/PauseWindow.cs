using Game.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseWindow : MonoBehaviour
{
    public void Pause()
    {
        GameManager.Instance.GameplayMode?.Pause();
    }
    public void Resume()
    {
        GameManager.Instance.GameplayMode?.Resume();
    }
    public void Restart()
    {
        GameManager.Instance.SetGameplayMode(null);
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        GameManager.Instance.SetGameplayMode(null);
        SceneManager.LoadSceneAsync(0);
    }
}
