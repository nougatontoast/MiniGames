using System.Collections;
using UnityEngine;

public class PickRandomOrGameOver : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    MySceneLoader mySceneLoader;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        mySceneLoader = FindObjectOfType<MySceneLoader>();

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
