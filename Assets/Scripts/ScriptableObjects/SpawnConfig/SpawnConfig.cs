using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpawnConfig : ScriptableObject
{
    [SerializeField] private GameObject objToSpawn = null;
    [SerializeField] private int maxSpawnables = new int();
    [SerializeField] private float minDelay = new float();
    [SerializeField] private float maxDelay = new float();

    public GameObject GetSpawnable() { return objToSpawn; }

    public int GetMaxSpawnables() { return maxSpawnables; }

    public float GetMinDelay() { return minDelay; }
    public float GetMaxDelay() { return maxDelay; }
}
