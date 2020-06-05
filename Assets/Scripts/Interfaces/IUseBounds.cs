using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUseBounds
{
    void UseBounds(Vector3 spawnCenter, Vector3 _colliderSize, Vector3 _colliderMin, Vector3 _colliderMax);
}
