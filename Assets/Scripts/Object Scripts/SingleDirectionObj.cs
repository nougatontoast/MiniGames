using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDirectionObj : MonoBehaviour
{
    MinigameHandler minigameHandler;

    [SerializeField] MovConfig movConfig = null;
    [SerializeField] Vector3 directionOfMotion = new Vector3();

    [SerializeField] private bool objStopOnGameOver = new bool();

    private bool shouldMove = true;

    private void Awake()
    {
        minigameHandler = FindObjectOfType<MinigameHandler>();

        if (objStopOnGameOver)
        {
            minigameHandler.GameOver += SetShouldMoveFalse;
        }
    }

    private void FixedUpdate()
    {
        MoveInDirection();
    }

    private void MoveInDirection()
    {
        if (shouldMove)
        {
            var posX = gameObject.transform.position.x + directionOfMotion.x * movConfig.GetMoveSpeed();
            var posY = gameObject.transform.position.y + directionOfMotion.y * movConfig.GetMoveSpeed();

            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }

    private void SetShouldMoveFalse()
    {
        shouldMove = false;
    }

}
