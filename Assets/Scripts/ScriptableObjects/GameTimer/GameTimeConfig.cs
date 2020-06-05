using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameTimeConfig : ScriptableObject
{
    [SerializeField] int totalTime = new int();

    public int GetTotalTime() { return totalTime; }
}
