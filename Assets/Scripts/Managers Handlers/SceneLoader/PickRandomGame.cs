using System.Collections;
using UnityEngine;

public class PickRandomGame : MySceneLoader
{
    private void Awake()
    {
        var currentScene = GetCurrentSceneName();
        if (currentScene.Equals("GameLobby"))
        {
            GetRandomGame_Delay();
        }
    }
}
