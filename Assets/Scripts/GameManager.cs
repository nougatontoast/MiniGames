﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] internal GameStartUi gameStartUi = null;
    [SerializeField] internal GameTimeConfig gameTimeConfig = null;
    [SerializeField] internal TimeUi timeUi = null;

    MySceneLoader mySceneLoader;

    //=======================//
    //                       //
    //      LOBBY STUFF      //
    //                       //
    //=======================//

    private bool inGameLobby = new bool();
    private bool isPickingGame = false;



    //=======================//
    //                       //
    //    MINI GAME STUFF    //
    //                       //
    //=======================//

    private bool inMiniGame = new bool();
    public bool gameStarted = false;
    public bool gameOver = false;

    // count down to start //
    private int maxCount = 3;
    internal int currentCount = new int();
    private bool isCounting = false;

    // count down to exit //
    private int maxExitCount = 1;
    internal float currentExitCount = new int();
    private bool isExitCounting = false;

    // mini game timer //
    private bool gameTimerCounting = false;
    private int countDownTo = new int();
    private float timeCounter = new int();

    // win lose tracking //
    public bool playerHasWon = false;
    public bool playerHasLost = false;

    private void Awake()
    {
        mySceneLoader = FindObjectOfType<MySceneLoader>();

        DetermineGameState();
    }

    private void Update()
    {
        if (inMiniGame)
        {
            if (!gameStarted)
            {
                SetUpMiniGameTimer();
                CountDownToStartGame();
            }
            else
            {
                if (!gameTimerCounting && timeCounter != 0 && !gameOver)
                {
                    StartCoroutine(MiniGameTimer(.01f));
                }
                if (timeCounter <= 0)
                {
                    gameOver = true;

                    if (!playerHasLost)
                    {
                        playerHasWon = true;
                    }
                }
                if (playerHasLost)
                {
                    gameOver = true;
                }
                if (gameOver)
                {
                    ReturnToLobby();
                }
            }
        }

        if (inGameLobby)
        {
            PickNewGame();
        }
    }

    private void DetermineGameState()
    {
        var currentScene = mySceneLoader.GetCurrentSceneName();

        if (currentScene.Equals("StartScene") || currentScene.Equals("GameLobby") || currentScene.Equals("Restart"))
        {
            inMiniGame = false;
        }
        else
        {
            currentCount = maxCount;
            inMiniGame = true;
        }

        if (currentScene.Equals("GameLobby"))
        {
            inGameLobby = true;
        }
    }

    //      Game to Lobby

    private void PickNewGame()
    {
        if (!isPickingGame)
        {
            StartCoroutine(DelayPickGame());
        }
    }

    private void ReturnToLobby()
    {
        if (currentExitCount != maxExitCount && !isExitCounting)
        {
            StartCoroutine(DelayGoToLobby(1));
        }
        if (currentExitCount >= maxExitCount)
        {
            mySceneLoader.GoToGameLobby();
        }
    }

    private IEnumerator DelayGoToLobby(float delayTime)
    {
        isExitCounting = true;
        yield return new WaitForSeconds(delayTime);

        currentExitCount += .5f;
        isExitCounting = false;
        yield break;
    }

    private IEnumerator DelayPickGame()
    {
        isPickingGame = true;
        Debug.Log("Picking game");

        yield return new WaitForSeconds(2);
        mySceneLoader.GetRandomGame();
        yield break;

    }

    //      Countdown to Start

    private void CountDownToStartGame()
    {
        if (currentCount >= 0)
        {
            if (!isCounting && !gameStarted)
            {
                isCounting = true;
                StartCoroutine(DelayCount(.5f));
            }
        }

        if (currentCount == 0)
        {
            gameStarted = true;
            gameStartUi.HidePreStartUI();
        }
    }

    public IEnumerator DelayCount(float delayTime)
    {
        if (gameStartUi != null)
        {
            gameStartUi.UpdateCountText(currentCount);
            yield return new WaitForSeconds(delayTime);
            currentCount--;
            isCounting = false;
            yield break;
        }
    }

    //      Minigame Timer

    private void SetUpMiniGameTimer()
    {
        countDownTo = gameTimeConfig.GetTotalTime();
        timeUi.SetMax(countDownTo);

        timeCounter = countDownTo;
        timeUi.SetTime(timeCounter);
    }

    public IEnumerator MiniGameTimer(float delayTime)
    {
        if (gameTimeConfig != null)
        {
            gameTimerCounting = true;
            yield return new WaitForSeconds(delayTime);

            timeCounter -= delayTime;
            timeUi.SetTime(timeCounter);
            gameTimerCounting = false;
            yield break;
        }
    }

}
