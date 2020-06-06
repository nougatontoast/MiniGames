using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUi : MonoBehaviour
{
    [SerializeField] private Slider slider = null;

    public void SetTime(float currentTime)
    {
        slider.value = currentTime;
    }

    public void SetMax(int maxValue)
    {
        slider.maxValue = maxValue;
    }
}
