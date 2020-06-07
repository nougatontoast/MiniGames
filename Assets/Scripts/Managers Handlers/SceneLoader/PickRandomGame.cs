using System.Collections;
using UnityEngine;

public class PickRandomGame : MySceneLoader
{
    private bool isPickingGame = new bool();

    private void Awake()
    {
        var currentScene = GetCurrentSceneName();
        if (currentScene.Equals("GameLobby"))
        {
            if (!isPickingGame)
            {
                StartCoroutine(DelayPickGame());
            }
        }
    }

    private IEnumerator DelayPickGame()
    {
        isPickingGame = true;

        yield return new WaitForSeconds(2);
        GetRandomGame();
        yield break;

    }
}
