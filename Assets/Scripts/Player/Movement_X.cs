using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_X : MonoBehaviour
{
    [Header("Parent")]
    [SerializeField] internal Player player = null;

    [Header("Internal References")]
    [SerializeField] internal PInput pInput = null;
    [SerializeField] internal MovConfig moveConfig = null;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (player.rb != null)
        {
            var velX = pInput.movementInput.x * moveConfig.GetMoveSpeed() * Time.fixedDeltaTime;
            Debug.Log(velX);
            player.rb.velocity = new Vector2(velX, player.rb.velocity.y);
        }
    }


    #region AutoAim
    /*            if (pInput.aimInput > .1f)
                {
                    player.rb.transform.LookAt(player.otherPlayer.transform);
                    player.aim.isAimingAtPlayer = true;
                }*/
    #endregion

}
