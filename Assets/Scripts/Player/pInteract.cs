using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pInteract : MonoBehaviour
{
    [SerializeField] Player player = null;
    [SerializeField] Vector3 interactBoxSize = new Vector3();
/*    [SerializeField] LayerMask interactableLayers = new LayerMask();*/

    private bool canUseButton = true;

    void Update()
    {
        InteractInRange();
    }

    private void InteractInRange()
    {

        if (player.pInput.interactInput > .1f && canUseButton)
        {

            canUseButton = false;
        }
        if (player.pInput.interactInput == 0)
        {
            canUseButton = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, interactBoxSize);
    }


}
