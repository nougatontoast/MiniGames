using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IId
{
    [Header("Configs")]
    [SerializeField] internal Id_Config id_Config = null;
    [SerializeField] internal SpriteConfig spriteConfig = null;

    [Header("Movement")]
    [SerializeField] internal List<GameObject> movementFunctionsUsed = new List<GameObject>();

    [Header("Input")]
    [SerializeField] internal PInput pInput = null;

    [Header("Other")]
    [SerializeField] internal pInteract pInteract = null;
    [SerializeField] internal Rigidbody2D rb = null;

    MinigameHandler minigameHandler;

    internal void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteConfig.GetDefaultSprite();

        minigameHandler = FindObjectOfType<MinigameHandler>();
        minigameHandler.PlayerLost += SetLoseSprite;
        minigameHandler.PlayerWon += SetWinSprite;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            minigameHandler.InvokeGameOver();
        }
    }

    private void FixedUpdate()
    {
        
    }


    #region IID region
    public string GetId()
    {
        return id_Config.GetIdViaSO();
    }

    public string GetObjType()
    {
        return id_Config.GetObjTypeViaSO();
    }
    #endregion


    private void SetLoseSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteConfig.GetLostSprite();
    }

    private void SetWinSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteConfig.GetWinSprite();
    }
}