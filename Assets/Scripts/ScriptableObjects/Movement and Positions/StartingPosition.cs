using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StartingPosition : ScriptableObject
{
    [SerializeField] private List<Vector3> startingPosition = new List<Vector3>();

}
