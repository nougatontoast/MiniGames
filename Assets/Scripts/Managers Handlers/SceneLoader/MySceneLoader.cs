using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneLoader : MonoBehaviour
{
    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void GoToGameLobby()
    {
        SceneManager.LoadScene("GameLobby");
    }

    public void GoToNewGame()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void GoToRestart()
    {
        SceneManager.LoadScene("Restart");
    }

    public void GoToGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void GetRandomGame()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        var selectedScene = Random.Range(3, sceneCount - 1);

        SceneManager.LoadScene(selectedScene);
    }

}
