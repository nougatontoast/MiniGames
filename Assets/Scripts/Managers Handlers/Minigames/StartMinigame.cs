using System.Collections.Generic;
using UnityEngine;

public class StartMinigame : MonoBehaviour
{
    [Header("Things To Enable On Start")]
    [SerializeField] internal List<GameObject> minigameElements = new List<GameObject>();


    private void Awake()
    {
        var minigameHandler = gameObject.GetComponent<MinigameHandler>();
        minigameHandler.GameStarted += EnableList;
    }

    private void EnableList()
    {
        foreach (GameObject element in minigameElements)
        {
            element.SetActive(true);
        }
    }
}
