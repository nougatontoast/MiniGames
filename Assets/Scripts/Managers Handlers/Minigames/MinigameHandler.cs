using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameHandler : GameManager
{
    [SerializeField] Timer_CountDown gameStartTimer = null;

    public delegate void OnGameStart();
    public event OnGameStart GameStarted;

    public delegate void OnGameOver();
    public event OnGameOver GameIsOver;

    public delegate void OnPlayerWin();
    public event OnPlayerWin PlayerWon;

    public delegate void OnPlayerLose();
    public event OnPlayerLose PlayerLost;

    private void Awake()
    {
        gameStartTimer.DownFinished += SetGameStarted;
    }

    public void SetGameStarted()
    {
        GameStarted?.Invoke();
    }

    public void SetGameOver()
    {
        GameIsOver?.Invoke();
    }

    public void PlayerWonTrue()
    {
        PlayerWon?.Invoke();
    }

    public void PlayerLostTrue()
    {
        PlayerLost?.Invoke();
    }
}
