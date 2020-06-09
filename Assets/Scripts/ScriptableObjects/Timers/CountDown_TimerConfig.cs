using UnityEngine;

[CreateAssetMenu (fileName = "Count Down", menuName = "Timer Config / New Count Down Config") ]
public class CountDown_TimerConfig : ScriptableObject
{
    [SerializeField] private float countDownFrom = new float();
    [SerializeField] private float downRate = new float();
    [SerializeField] private float endThresholdTop = new float();
    [SerializeField] private float endThresholdBottom = new float();

    public float GetCountDownFrom() { return countDownFrom; }
    public float GetDownRate() { return downRate; }

    public float GetEndThresholdTop() { return endThresholdTop; }
    public float GetEndThresholdBottom() { return endThresholdBottom; }
}
