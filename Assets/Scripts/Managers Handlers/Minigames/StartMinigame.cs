using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMinigame : MinigameHandler
{
    [Header("Things To Enable On Start")]
    [SerializeField] internal List<GameObject> minigameElements = new List<GameObject>();


    private void Awake()
    {

        var minigameHandler = gameObject.GetComponent<MinigameHandler>();
        minigameHandler.GameStarted += EnableList;
        minigameHandler.GameIsOver += DisableList;

    }

    private void DisableList()
    {
        foreach (GameObject element in minigameElements)
        {
            element.SetActive(false);
        }
    }

    private void EnableList()
    {
        foreach (GameObject element in minigameElements)
        {
            element.SetActive(true);
        }
    }
}
