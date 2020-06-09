using System.Collections.Generic;
using UnityEngine;

public class EndMinigame : MonoBehaviour
{
    [Header("Things To Disable At End")]
    [SerializeField] internal List<GameObject> minigameElements = new List<GameObject>();


    private void Awake()
    {
        var theMinigameHandler = gameObject.GetComponent<MinigameHandler>();
        theMinigameHandler.GameOver += DisableList;
    }

    private void DisableList()
    {
        foreach (GameObject element in minigameElements)
        {
            element.SetActive(false);
        }
    }
}
