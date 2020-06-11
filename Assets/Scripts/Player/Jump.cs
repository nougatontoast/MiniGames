using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private Player player = null;
    [SerializeField] private MovConfig movConfig = null;

    IdManager idManager = null;

    private float jumpSpeed = new float();
    private Rigidbody2D rb = null;
    private bool canJump = true;

    private void Awake()
    {
        idManager = FindObjectOfType<IdManager>();
        jumpSpeed = movConfig.GetJumpSpeed() * Time.fixedDeltaTime;

        rb = player.rb;
        rb.gravityScale = 3f;
    }
    private void Update()
    {
        if (player.pInput.interactInput >= .1f && canJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var thisId = idManager.GetObjId(collision.gameObject);

        if (thisId != null)
        {
            if (thisId.Equals("floor"))
            {
                canJump = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var thisId = idManager.GetObjId(collision.gameObject);

        if (thisId != null)
        {
            if (thisId.Equals("floor"))
            {
                canJump = false;
            }
        }
    }

}
