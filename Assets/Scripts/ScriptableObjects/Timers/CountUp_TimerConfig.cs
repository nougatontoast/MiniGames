using UnityEngine;

[CreateAssetMenu(fileName = "Count Up", menuName = "Timer Config / New Count Up Config")]
public class CountUp_TimerConfig : ScriptableObject
{
    [SerializeField] private float countUpTo = new float();
    public float GetCountUpTo() { return countUpTo; }
}
