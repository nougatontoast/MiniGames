using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MovConfig : ScriptableObject
{
    [SerializeField] private float moveSpeed = new float();
    [SerializeField] private float jumpSpeed = new float();

    public float GetMoveSpeed() { return moveSpeed; }
    public float GetJumpSpeed() { return jumpSpeed; }
}
