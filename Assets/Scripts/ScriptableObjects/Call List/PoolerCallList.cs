using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public struct ItemAmountForPool
{
    public GameObject ObjectToPool;
    public int NumberToInst;
}

[CreateAssetMenu(fileName = "New Pooler List")]
public class PoolerCallList : ScriptableObject
{
    [SerializeField] string sceneMatch = null;
    [SerializeField] private List<ItemAmountForPool> objectsToInst = null;

    public string ReturnSceneMatch() { return sceneMatch; }
    public List<ItemAmountForPool> GetListofPrefabs() { return objectsToInst; }
}