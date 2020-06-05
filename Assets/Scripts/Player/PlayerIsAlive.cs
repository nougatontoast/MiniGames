using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsAlive : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        IId id = collision.gameObject.GetComponent<IId>();
        if (id != null)
        {
            id.GetId();
        }
    }
}
