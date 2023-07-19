using UnityEngine;
using Game.Framework;

public class Initialization_GameplayMode : GameplayMode
{
    [SerializeField] private GameObject controller;
    [SerializeField] private GameObject pauseWindow;
    [SerializeField] private GameplayMode basketball_GameplayMode;

    public override void Initialize()
    {
        controller.SetActive(false);
        pauseWindow.SetActive(false);
    }

    public override void Pause()
    {
        Time.timeScale = 0F;
        controller.SetActive(false);
        pauseWindow.SetActive(true);
    }

    public override void Play()
    {
        Time.timeScale = 1;
        controller.SetActive(true);
    }

    public override void Resume()
    {
        Time.timeScale = 1F;
        pauseWindow.SetActive(false);
        controller.SetActive(true);
    }

    public override void Stop()
    {
        Time.timeScale = 1F;
        pauseWindow.SetActive(false);
        controller.SetActive(false);
    }
}
