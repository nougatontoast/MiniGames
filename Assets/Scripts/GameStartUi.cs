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
        goalText.GetComponent<TMPro.TextMeshProUGUI>().text = textConfig.GetText();
    }
    
    internal void UpdateCountText(int countNum)
    {
        countDown.GetComponent<TMPro.TextMeshProUGUI>().text = countNum.ToString();
    }

    internal void HidePreStartUI()
    {
        goalText.SetActive(false);
        countDown.SetActive(false);
    }

}
