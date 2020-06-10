using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] internal bool testingMinigame = new bool();

    MySceneLoader mySceneLoader;

    private int instanceCount = new int();

    private int totalPlayerLives = 3;
    private int currentPlayerLives = new int();

    /*    private int difficultyLevel = 1;
        private int maxSuccessesNeeded = 3;
        private int currentSuccessCount = 0;*/

    public delegate void OnLivesZero();
    public event OnLivesZero LivesZero;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void Start()
    {
        mySceneLoader = FindObjectOfType<MySceneLoader>();

        if (testingMinigame)
        {
            currentPlayerLives = 3;
        }


        if (mySceneLoader.GetCurrentSceneName().Equals("StartScene"))
        {
            ResetLives();
        }
    }

    private void Update()
    {
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

    public void SubtractLife()
    {
        currentPlayerLives -= 1;
    }

    public int GetCurrentLives()
    {
        return currentPlayerLives;
    }
}
