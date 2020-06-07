using UnityEngine;

[CreateAssetMenu (fileName = "Count Down", menuName = "Timer Config / New Count Down Config") ]
public class CountDown_TimerConfig : ScriptableObject
{
    [SerializeField] private float countDownFrom = new float();

    public float GetCountDownFrom() { return countDownFrom; }
}
