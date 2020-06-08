using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameHandler : GameManager
{
    [SerializeField] Timer_CountDown gameStartTimer = null;

    public delegate void OnGameStart();
    public event OnGameStart GameStarted;

    public delegate void OnGameOver();
    public event OnGameOver GameOver;

    public delegate void OnPlayerLost();
    public event OnPlayerLost PlayerLost;

    public delegate void OnPlayerWon();
    public event OnPlayerWon PlayerWon;

    private void Awake()
    {
        gameStartTimer.DownFinished += InvokeGameStarted;
    }

    public void InvokeGameStarted() => GameStarted?.Invoke();

    public void InvokeGameOver() => GameOver?.Invoke();

    public void InvokePlayerLost()
    {
        PlayerLost?.Invoke();
        InvokeGameOver();
    }

    public void InvokePlayerWon()
    {
        PlayerWon?.Invoke();
        InvokeGameOver();
    }

}
