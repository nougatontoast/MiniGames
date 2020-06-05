using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    SceneLoader sceneLoader;

    private int instanceCount = new int();

    private int totalPlayerLives = 3;
    private int currentPlayerLives = new int();

    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        SetUpSingleton();
        
        if (sceneLoader.GetCurrentSceneName().Equals("StartScene"))
        {
            ResetLives();
        }
    }

    private void SetUpSingleton()
    {
        int scoreKeeperCount = FindObjectsOfType<ScoreKeeper>().Length;
        instanceCount = scoreKeeperCount;
        if (scoreKeeperCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetLives()
    {
        currentPlayerLives = totalPlayerLives;
    }
}
