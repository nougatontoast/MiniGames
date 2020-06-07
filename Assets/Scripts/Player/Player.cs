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

    internal void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteConfig.GetDefaultSprite();
    }

    private void Update()
    {
/*        SetMovementIfGameStarted();
        SetWinOrLoseSprite();*/
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


/*    private void SetWinOrLoseSprite()
    {
        if (gameManager.playerHasWon)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteConfig.GetWinSprite();
        }
        if (gameManager.playerHasLost)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteConfig.GetLostSprite();
        }
    }*/
}