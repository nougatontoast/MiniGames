using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_CountUp : MonoBehaviour
{
    [SerializeField] private CountUp_TimerConfig timerConfig = null;

    private float countUpTo = new float();
    private float currentTime_GoingUp = new float();
    private bool isCountingUp = false;

    public delegate void OnTimerUp();
    public event OnTimerUp UpFinished;

    private void Awake()
    {
        SetUpVars();
    }

    private IEnumerator DelayCountUp()
    {
        isCountingUp = true;
        yield return new WaitForSeconds(.1f);

        currentTime_GoingUp += .1f;

        isCountingUp = false;
        yield break;

    }

    private void SetUpVars()
    {
        countUpTo = timerConfig.GetCountUpTo();
        currentTime_GoingUp = countUpTo;
    }

    public void CountUp()
    {

        if (currentTime_GoingUp >= countUpTo)
        {
            if (!isCountingUp)
            {
                StartCoroutine(DelayCountUp());
            }
        }

        if (currentTime_GoingUp == countUpTo)
        {
            UpFinished?.Invoke();
        }
    }
}
