using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionInBounds : Bounds
{

    private void Start()
    {
        SetPositionWIthinBounds();
    }

    private void SetPositionWIthinBounds()
    {
        float x = Random.Range(_colliderMin.x, _colliderMax.x);
        float y = Random.Range(_colliderMin.y, _colliderMax.y);

        Vector3 spawnPos = new Vector3(x, y, 0);
        gameObject.transform.position = spawnPos;

        Debug.Log("Spawning at " + spawnPos);
    }
}
