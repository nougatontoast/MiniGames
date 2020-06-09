using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Timer_CountDown : MonoBehaviour
{
    [SerializeField] internal CountDown_TimerConfig timerConfig = null;

    private float downRate = new float();

    private float endThresholdTop = new float();
    private float endThresholdBottom = new float();

    private bool isCountingDown = false;

    internal float countDownFrom = new float();
    internal float currentTime_GoingDown = new float();

    public delegate void OnTimerDown();
    public event OnTimerDown DownFinished;

    private void OnEnable()
    {
        SetDownVars();
    }

    private void Update()
    {
        CountDown();
    }

    private void SetDownVars()
    {
        countDownFrom = timerConfig.GetCountDownFrom();
        downRate = timerConfig.GetDownRate();
        endThresholdTop = timerConfig.GetEndThresholdTop();
        endThresholdBottom = timerConfig.GetEndThresholdBottom();
        currentTime_GoingDown = countDownFrom;
    }

    private IEnumerator DelayCountDown()
    {
        isCountingDown = true;
        yield return new WaitForSeconds(downRate);

        currentTime_GoingDown -= downRate;

        isCountingDown = false;
        yield break;
    }

    private void CountDown()
    {
        if (currentTime_GoingDown >= 0)
        {
            if (!isCountingDown)
            {
                StartCoroutine(DelayCountDown());
            }
        }
        if (currentTime_GoingDown < endThresholdTop && currentTime_GoingDown > endThresholdBottom)
        {
            DownFinished?.Invoke();
            gameObject.SetActive(false);
        }
    }

    public float ReturnCurrentTime()
    {
        return currentTime_GoingDown;
    }
}
