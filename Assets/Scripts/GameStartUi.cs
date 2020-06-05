using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartUi : MonoBehaviour
{
    [SerializeField] internal GameManager gameManager = null;
    [SerializeField] internal TextConfig textConfig = null;

    [SerializeField] private GameObject goalText = null;
    [SerializeField] private GameObject countDown = null;

    private void Awake()
    {
        SetGoalText();
    }

    private void SetGoalText()
    {
        goalText.GetComponent<TextMesh>().text = textConfig.GetText();
    }
    
    internal void UpdateCountText(int countNum)
    {
        countDown.GetComponent<Text>().text = countNum.ToString();
    }

}
