using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneLoader : MonoBehaviour
{
    [SerializeField] Timer_CountDown delayActionCounter = null;

    private void Awake()
    {
        var theMinigameHandler = FindObjectOfType<MinigameHandler>();
        if (theMinigameHandler != null)
        {
            theMinigameHandler.GameOver += GoToGameLobby_Delay;
        }
        else
        {
            return;
        }
    }

    private void RemoveGoToGameLobby()
    {
        delayActionCounter.DownFinished -= GoToGameLobby_Command;
    }

    private void RemoveGetRandomGame()
    {
        delayActionCounter.DownFinished -= GetRandomGame_Command;
    }

    internal void GoToGameLobby_Command()
    {

        SceneManager.LoadScene("GameLobby");
    }

    internal void GetRandomGame_Command()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        var selectedScene = Random.Range(3, sceneCount - 1);

        SceneManager.LoadScene(selectedScene);
    }

    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void GoToNewGame()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void GoToRestart()
    {
        SceneManager.LoadScene("Restart");
    }

    public void GetRandomGame_Delay()
    {
        delayActionCounter.enabled = true;
        delayActionCounter.DownFinished += GetRandomGame_Command;
        delayActionCounter.DownFinished += RemoveGetRandomGame;
    }

    public void GoToGameLobby_Delay()
    {
        delayActionCounter.enabled = true;
        delayActionCounter.DownFinished += GoToGameLobby_Command;
        delayActionCounter.DownFinished += RemoveGoToGameLobby;
    }

}
