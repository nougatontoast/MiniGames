using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Timer_CountDown : MonoBehaviour
{
    [SerializeField] private CountDown_TimerConfig timerConfig = null;

    private float countDownFrom = new float();
    private float currentTime_GoingDown = new float();
    private bool isCountingDown = false;

    public delegate void OnTimerDown();
    public event OnTimerDown DownFinished;

    private void Awake()
    {
        SetDownVars();
    }

    private void Update()
    {
        CountDown();
    }

    private IEnumerator DelayCountDown()
    {
        isCountingDown = true;
        yield return new WaitForSeconds(.1f);

        currentTime_GoingDown -= .1f;

        isCountingDown = false;
        yield break;
    }

    private void SetDownVars()
    {
        countDownFrom = timerConfig.GetCountDownFrom();
        currentTime_GoingDown = countDownFrom;
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
        if (currentTime_GoingDown < .9f && currentTime_GoingDown > .7f)
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
