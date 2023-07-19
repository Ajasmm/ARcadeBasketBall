using UnityEngine;
using Game.Framework;

public class BasketBall_LevelManager : LevelManager
{
    [SerializeField] private GameplayMode initialGameplayMode;
    [SerializeField] private GameplayMode basketballGameplayMode;

    [SerializeField] private PostPlacer postPlacer;

    public override void OnStart()
    {
        GameManager.Instance.SetGameplayMode(initialGameplayMode);
        GameManager.Instance.GameplayMode.Play();
        postPlacer.OnPostPlaced += OnPostPlaced;
    }
    public void OnPostPlaced()
    {
        GameManager.Instance.SetGameplayMode(basketballGameplayMode);
        GameManager.Instance.GameplayMode.Play();
    }
}
