using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeOnLose : MonoBehaviour
{
    MinigameHandler minigameHandler;

    private Rigidbody2D rb = null;

    private void Awake()
    {
        minigameHandler = FindObjectOfType<MinigameHandler>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        minigameHandler.GameOver += FreezeRb;
    }

    private void FreezeRb()
    {
        rb.gravityScale = 0;
        rb.velocity = new Vector3(0, 0, 0);
    }
}
