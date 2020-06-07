using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : BasicObject
{
    [SerializeField] private bool destroyOnCollide = new bool();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (destroyOnCollide)
        {
            pooler.ReturnToPool(gameObject);
        }
    }

    private IEnumerator DelayReturn(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        pooler.ReturnToPool(gameObject);
        yield break;
    }
}
