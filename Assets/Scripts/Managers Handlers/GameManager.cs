using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] internal MiniGameStartUI gameStartUi = null;
    [SerializeField] internal TimeUi timeUi = null;

    internal ScoreKeeper scoreKeeper = null;
    internal MySceneLoader mySceneLoader = null;

    private bool playerShouldLoseLife = new bool();

    /////////////////////////////////////////////////////////////////////////

    private string currentScene = null;

    private void Awake()
    {
        mySceneLoader = FindObjectOfType<MySceneLoader>();
        currentScene = mySceneLoader.GetCurrentSceneName();
    }




}
