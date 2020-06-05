using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOOGControl : MonoBehaviour
{
    SceneLoader sceneLoader;
    [SerializeField] PInput pInput = null;

    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void Update()
    {
        NewGame();
    }

    private void NewGame()
    {
        if (pInput.interactInput > .1f)
        {
            sceneLoader.GoToGameLobby();
        }
    }
}
