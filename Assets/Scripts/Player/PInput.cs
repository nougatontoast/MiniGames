using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PInput : MonoBehaviour
{
    [Header("Parent")]
    [SerializeField] internal Player player = null;

    [Header("Player Id")]
    [SerializeField] internal int playerId = new int();

    [Header("Input Axes")]
    [SerializeField] string horizontalControl = null;
    [SerializeField] string verticalControl = null;
    [SerializeField] string interactButton = null;


    internal Vector3 movementInput = new Vector3();
    internal float interactInput = new float();

    private void Awake()
    {
        SetUpPlayerControls();
    }

    private void Update()
    {
        GetHorVertInput();
        GetButtonInput();
    }

    private void SetUpPlayerControls()
    {
        if (playerId == 0)
        {
            horizontalControl = "Horizontal_P1";
            verticalControl = "Vertical_P1";
            interactButton = "Interact_P1";
        }

        else if (playerId == 1)
        {
            horizontalControl = "Horizontal_P2";
            verticalControl = "Vertical_P2";
            interactButton = "Interact_P2";
        }
    }

    private void GetHorVertInput()
    {
        movementInput.x = Input.GetAxis(horizontalControl);
        movementInput.y = Input.GetAxis(verticalControl);
    }

    private void GetButtonInput()
    {
        interactInput = Input.GetAxis(interactButton);
    }
}