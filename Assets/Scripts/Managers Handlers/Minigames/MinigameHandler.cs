﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameHandler : GameManager
{
    [Header("Timer References")]
    [SerializeField] Timer_CountDown gameStartTimer = null;
    [SerializeField] Timer_CountDown gameEndTimer = null;

    [Header("Set Game Type")]
    [SerializeField] private bool winAtEndIfHasntLost = new bool();
    [SerializeField] private bool loseAtEndIfHasntWon = new bool();

    ScoreKeeper theScoreKeeper;

    private bool playerWonInvoked = new bool();
    private bool playerLostInvoked = new bool();
    private bool gameOverInkvoked = new bool();

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

        theScoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void InvokeGameStarted() => GameStarted?.Invoke();

    public void InvokeGameOver()
    {
        gameOverInkvoked = true;

        if (winAtEndIfHasntLost)
        {
            if (!playerLostInvoked)
            {
                InvokePlayerWon();
            }
        }
        if (loseAtEndIfHasntWon)
        {
            if (!playerWonInvoked)
            {
                if (!playerLostInvoked)
                {
                    theScoreKeeper.SubtractLife();
                    InvokePlayerLost();
                }
            }
        }

        GameOver?.Invoke();
    }

    public void InvokePlayerLost()
    {
        if (!playerLostInvoked)
        {
            playerLostInvoked = true;
            PlayerLost?.Invoke();
            theScoreKeeper.SubtractLife();
        }

        if (!gameOverInkvoked)
        {
            InvokeGameOver();
        }
    }

    public void InvokePlayerWon()
    {
        if (!playerWonInvoked)
        {
            Debug.Log("PLayerWon has been invoked");
            PlayerWon?.Invoke();

            if (PlayerWon == null)
            {
                Debug.Log("PlayerWon is null");
            }

            playerWonInvoked = true;
        }

        if (!gameOverInkvoked)
        {
            InvokeGameOver();
        }
    }

}
