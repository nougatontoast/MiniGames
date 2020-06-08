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

    public delegate void OnPlayerWin();
    public event OnPlayerWin PlayerWon;

    public delegate void OnPlayerLose();
    public event OnPlayerLose PlayerLost;

    private void Awake()
    {
        gameStartTimer.DownFinished += InvokeGameStarted;
    }

    public void InvokeGameStarted() => GameStarted?.Invoke();

    public void InvokeGameOver()
    {
        Debug.Log("Game over");
        GameOver?.Invoke();

        if (GameOver == null)
        {
            Debug.Log("GameOver is null");
        }
    }

    public void PlayerWonTrue()
    {
        PlayerWon?.Invoke();
        InvokeGameOver();
    }

    public void PlayerLostTrue()
    {
        PlayerLost?.Invoke();
        InvokeGameOver();
    }
}
