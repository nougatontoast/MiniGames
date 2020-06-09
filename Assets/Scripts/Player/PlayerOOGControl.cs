using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOOGControl : MySceneLoader
{
    [SerializeField] PInput pInput = null;

    private void Update()
    {
        NewGame();
    }

    private void NewGame()
    {
        if (pInput.interactInput > .1f)
        {
            GoToGameLobby_Command();
        }
    }
}
