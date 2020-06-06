using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    MySceneLoader sceneLoader;
    GameManager gameManager;

    private int instanceCount = new int();

    private int totalPlayerLives = 3;
    private int currentPlayerLives = new int();
    private bool currentLifeTotalCanChange = new bool();

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        sceneLoader = FindObjectOfType<MySceneLoader>();

        SetUpSingleton();
        
        if (sceneLoader.GetCurrentSceneName().Equals("StartScene"))
        {
            ResetLives();
        }
    }

    private void Update()
    {
        if (!gameManager.playerHasLost)
        {
            Debug.Log("Player Has Lost = " + gameManager.playerHasLost);
            currentLifeTotalCanChange = true;
        }
        else
        {
            Debug.Log("Player Has Lost = " + gameManager.playerHasLost);
            if (currentLifeTotalCanChange)
            {
                SubtractLife();
                currentLifeTotalCanChange = false;
            }

            if (currentPlayerLives <= 0)
            {
                sceneLoader.GoToRestart();
            }
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

    private void ResetLives()
    {
        currentPlayerLives = totalPlayerLives;
    }

    private void SubtractLife()
    {
        currentPlayerLives--;
    }

    public int GetLifeTotal()
    {
        return totalPlayerLives;
    }
}
