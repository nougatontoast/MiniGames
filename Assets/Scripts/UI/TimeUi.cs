﻿using UnityEngine;
using UnityEngine.UI;

public class TimeUi : MonoBehaviour
{
    [SerializeField] internal Slider slider = null;
    [SerializeField] internal Timer_CountDown gameEndCounter = null;

    private void Update()
    {
        SetTime(gameEndCounter.currentTime_GoingDown);
    }

    public void SetTime(float currentTime)
    {
        slider.value = currentTime;
    }
}
