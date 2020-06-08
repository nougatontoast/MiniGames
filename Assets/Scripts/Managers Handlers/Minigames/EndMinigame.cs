using System.Collections.Generic;
using UnityEngine;

public class EndMinigame : MonoBehaviour
{
    [Header("Things To Disable On Start")]
    [SerializeField] internal List<GameObject> minigameElements = new List<GameObject>();


    private void Awake()
    {
        Debug.Log("End awake");
        var minigameHandler = gameObject.GetComponent<MinigameHandler>();
        minigameHandler.GameOver += DisableList;
    }

    private void DisableList()
    {
        Debug.Log("Disable list");
        foreach (GameObject element in minigameElements)
        {
            element.SetActive(false);
        }
    }
}
