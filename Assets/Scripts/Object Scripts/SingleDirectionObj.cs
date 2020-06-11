using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDirectionObj : BasicObject_NoSprite
{
    [SerializeField] MovConfig movConfig = null;
    [SerializeField] Vector3 directionOfMotion = new Vector3();

    private void FixedUpdate()
    {
        MoveInDirection();
    }

    private void MoveInDirection()
    {
        var posX = gameObject.transform.position.x + directionOfMotion.x * movConfig.GetMoveSpeed();
        var posY = gameObject.transform.position.y + directionOfMotion.y * movConfig.GetMoveSpeed();

        transform.position = new Vector3(posX, posY, transform.position.z);
    }

}
