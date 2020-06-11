using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] GameObject objToFollow = null;

    private Vector2 targetPos = new Vector2();

    private void Awake()
    {
    }

    private void Update()
    {
        targetPos = objToFollow.transform.position;
    }
}
