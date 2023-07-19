using Game.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndWindow : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    private void OnEnable()
    {
        Basketball_GameplayMode gameplayMode = GameManager.Instance.GameplayMode as Basketball_GameplayMode;
        if (gameplayMode == null)
            return;

        scoreText.text = gameplayMode.score.ToString();
    }

    public void Menu()
    {
        GameManager.Instance.SetGameplayMode(null);
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void Restart()
    {
        SceneManager.LoadScene(gameObject.scene.buildIndex, LoadSceneMode.Single);
    }
}
