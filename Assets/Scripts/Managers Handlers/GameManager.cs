﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    MySceneLoader mySceneLoader;

    private string currentScene = null;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        mySceneLoader = FindObjectOfType<MySceneLoader>();

        currentScene = mySceneLoader.GetCurrentSceneName();

        DetectAndSetNewGame();
        PickRandomGameOrGoToRestart();
    }

    private void DetectAndSetNewGame()
    {
        if (currentScene.Equals("StartScene"))
        {
            scoreKeeper.ResetLives();
        }
    }

    private void PickRandomGameOrGoToRestart()
    {
        var currentScene = mySceneLoader.GetCurrentSceneName();
        if (currentScene.Equals("GameLobby"))
        {
            var currentLives = scoreKeeper.GetCurrentLives();

            if (currentLives > 0)
            {
                mySceneLoader.GetRandomGame_Delay();
            }
            else
            {
                mySceneLoader.GoToRestart_Delay();
            }
        }
    }



}
