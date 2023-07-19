using Game.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameplayController : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text time;

    public static bool IsBallTouchedTheGround = false; 

    private void OnEnable()
    {
        Basketball_GameplayMode gameplayMode = GameManager.Instance.GameplayMode as Basketball_GameplayMode;
        if (gameplayMode != null)
            gameplayMode.OnScoreChange += OnScorechange;
    }
    private void OnDisable()
    {
        Basketball_GameplayMode gameplayMode = GameManager.Instance.GameplayMode as Basketball_GameplayMode;
        if (gameplayMode != null)
            gameplayMode.OnScoreChange += OnScorechange;
    }

    private void Update()
    {
        Basketball_GameplayMode gameplayMode = GameManager.Instance.GameplayMode as Basketball_GameplayMode;
        int timeSecond = (int)gameplayMode.TimeRemaining;
        time.text = timeSecond.ToString();
    }
    private void OnScorechange(int newScore)
    {
        score.text = newScore.ToString();
    }
}
