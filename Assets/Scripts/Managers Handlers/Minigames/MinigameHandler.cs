using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameHandler : GameManager
{
    [SerializeField] Timer_CountDown gameStartTimer = null;
    [SerializeField] Timer_CountDown gameEndTimer = null;

    [SerializeField] private bool winAtEndIfHasntLost = new bool();
    [SerializeField] private bool loseAtEndIfHasntWon = new bool();

    private bool playerWon = new bool();
    private bool playerLost = new bool();

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
        gameEndTimer.DownFinished += InvokeGameOver;
    }

    public void InvokeGameStarted() => GameStarted?.Invoke();

    public void InvokeGameOver()
    {
        if (winAtEndIfHasntLost)
        {
            if (!playerLost)
            {
                playerWon = true;
            }
        }
        if (loseAtEndIfHasntWon)
        {
            if (!playerWon)
            {
                playerLost = true;
            }
        }

        GameOver?.Invoke();
    }

    public void InvokePlayerLost()
    {
        PlayerLost?.Invoke();
        playerLost = true;
        InvokeGameOver();
    }

    public void InvokePlayerWon()
    {
        PlayerWon?.Invoke();
        playerWon = true;
        InvokeGameOver();
    }

}
