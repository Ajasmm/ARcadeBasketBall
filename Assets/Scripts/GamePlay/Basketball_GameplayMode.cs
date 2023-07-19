using UnityEngine;
using Game.Framework;
using System;

public class Basketball_GameplayMode : GameplayMode
{
    [SerializeField] private GameObject ControllerCanvas;
    [SerializeField] private GameObject PauseCanvas;
    [SerializeField] private GameObject WinCanvas;
    [SerializeField] private GameObject FailCanvas;
    [SerializeField] float matchTime = 60;

    public bool isPlaying { get; private set; }
    public float TimeRemaining { get; private set; }

    public Action<int> OnScoreChange;
    public int score { get; private set; }

    public override void Initialize()
    {
        ControllerCanvas.SetActive(false);
        PauseCanvas.SetActive(false);
        FailCanvas.SetActive(false);
        WinCanvas.SetActive(false);

        TimeRemaining = matchTime;
        isPlaying = false;
        score = 0;
    }
    public override void Pause()
    {
        Time.timeScale = 0;
        ControllerCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
        isPlaying = false;
    }
    public override void Play()
    {
        ControllerCanvas.SetActive(true);
        PauseCanvas.SetActive(false);
        isPlaying = true;
    }
    public override void Resume()
    {
        Time.timeScale = 1;
        ControllerCanvas.SetActive(true);
        PauseCanvas.SetActive(false);
        isPlaying = true;
    }
    public override void Stop()
    {
        Time.timeScale = 1;
        ControllerCanvas.SetActive(false);
        PauseCanvas.SetActive(false);
        isPlaying = false;
    }
    public override void Win()
    {
        Stop();
        WinCanvas.SetActive(true);
    }
    public override void Fail()
    {
        Stop();
        FailCanvas.SetActive(true);
    }


    public override void OnUpdate()
    {
        if (!isPlaying) return;
        TimeRemaining -= Time.deltaTime;

        if(TimeRemaining < 0)
        {
            TimeRemaining = 0;
            Fail();
        }
    }
    public void AddScore(int score)
    {
        this.score += score;
        OnScoreChange?.Invoke(this.score);
    }
}
