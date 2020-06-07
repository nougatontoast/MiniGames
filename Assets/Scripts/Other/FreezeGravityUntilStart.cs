using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGravityUntilStart : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] private Rigidbody2D rb = null;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
/*        if (!gameManager.gameStarted && !gameManager.gameOver)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }*/
    }
}
