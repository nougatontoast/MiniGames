using UnityEngine;
using UnityEngine.UI;

public class SetUpTimeUi : MonoBehaviour
{
    [SerializeField] internal Slider slider = null;
    [SerializeField] internal Timer_CountDown gameEndCounter = null;

    private void Awake()
    {
        SetTime(gameEndCounter.timerConfig.GetCountDownFrom());
    }

    private void SetTime(float currentTime)
    {
        slider.value = currentTime;
    }
}
