using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private Player player = null;
    [SerializeField] private MovConfig movConfig = null;

    private float jumpSpeed = new float();
    private Rigidbody2D rb = null;

    private void Awake()
    {
        jumpSpeed = movConfig.GetJumpSpeed() * Time.fixedDeltaTime;
        rb = player.rb;

        rb.gravityScale = 2.5f;
    }
    private void Update()
    {
        if (player.pInput.interactInput >= .1f)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed);
        }
    }

}
