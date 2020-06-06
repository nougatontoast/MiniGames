using UnityEngine;

public class Player : MonoBehaviour, IId
{
    GameManager gameManager;

    [Header("Internal Ref")]
    [SerializeField] internal Id_Config id_Config = null;
    [SerializeField] internal SpriteConfig spriteConfig = null;
    [SerializeField] internal Movement movement = null;
    [SerializeField] internal PInput pInput = null;
    [SerializeField] internal pInteract pInteract = null;
    [SerializeField] internal Rigidbody2D rb = null;

    internal void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteConfig.GetDefaultSprite();
    }

    private void Update()
    {
        SetMovementIfGameStarted();
        SetWinOrLoseSprite();
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

    private void SetMovementIfGameStarted()
    {
        if (gameManager.gameStarted)
        {
            movement.enabled = true;
        }
        else
        {
            movement.enabled = false;
        }

        if (gameManager.gameOver)
        {
            rb.velocity = new Vector3(0, 0, 0);
            movement.enabled = false;
        }
    }    

    private void SetWinOrLoseSprite()
    {
        if (gameManager.playerHasWon)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteConfig.GetWinSprite();
        }
        if (gameManager.playerHasLost)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteConfig.GetLostSprite();
        }
    }
}