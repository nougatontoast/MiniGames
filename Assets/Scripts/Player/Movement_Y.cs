using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Y : MonoBehaviour
{
    [Header("Parent")]
    [SerializeField] internal Player player = null;

    [Header("Internal References")]
    [SerializeField] internal PInput pInput = null;
    [SerializeField] internal MovConfig moveConfig = null;

    private void OnDisable()
    {
        player.rb.velocity = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (player.rb != null)
        {
            var velY = pInput.movementInput.y * moveConfig.GetMoveSpeed() * Time.fixedDeltaTime;
            player.rb.velocity = new Vector2(player.rb.velocity.x, velY);
        }
    }
}
