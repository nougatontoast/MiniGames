using System.Collections.Generic;
using UnityEngine;

public class EndMinigame : MonoBehaviour
{
    [Header("Things To Disable At End")]
    [SerializeField] internal List<GameObject> minigameElements = new List<GameObject>();


    private void Awake()
    {
        Debug.Log("End awake");
        var theMinigameHandler = gameObject.GetComponent<MinigameHandler>();
        theMinigameHandler.GameOver += DisableList;
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
