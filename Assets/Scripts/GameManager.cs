using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] internal GameStartUi gameStartUi = null;
    [SerializeField] internal GameTimeConfig gameTimeConfig = null;

    SceneLoader sceneLoader;

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

    // count down to start //
    private int maxCount = 3;
    internal int currentCount = new int();
    private bool isCounting = false;

    // mini game timer //
    private bool gameTimerCounting = false;
    private int countDownFrom = new int();
    private int timeLeft = new int();

    // win lose tracking //
    public bool playerHasWon = new bool();
    public bool playerHasLost = new bool();

    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        DetermineGameState();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (inMiniGame)
        {
            SetUpMiniGameTimer();
            CountDownToStartGame();

            if (gameStarted)
            {
                if (!gameTimerCounting)
                {
                    StartCoroutine(MiniGameTimer(1f));
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
        var currentScene = sceneLoader.GetCurrentSceneName();

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

    private void PickNewGame()
    {
        if (!isPickingGame)
        {
            StartCoroutine(DelayPickGame());
        }
    }

    private IEnumerator DelayPickGame()
    {
        isPickingGame = true;
        Debug.Log("Picking game");

        yield return new WaitForSeconds(2);
        sceneLoader.GetRandomGame();
        yield break;

    }

    private void CountDownToStartGame()
    {
        if (currentCount >= 0)
        {
            if (!isCounting)
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

    private void SetUpMiniGameTimer()
    {
        countDownFrom = gameTimeConfig.GetTotalTime();
        timeLeft = countDownFrom;
    }

    public IEnumerator MiniGameTimer(float delayTime)
    {
        if (gameTimeConfig != null)
        {
            gameTimerCounting = true;
            yield return new WaitForSeconds(delayTime);

            timeLeft--;
            gameTimerCounting = false;
            yield break;
        }
    }

}
