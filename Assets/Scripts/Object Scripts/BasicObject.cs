using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicObject : MonoBehaviour, IId
{
    [SerializeField] Id_Config id_Config = null;
    [SerializeField] SpriteConfig spriteConfig = null;

    internal Pooler pooler = null;

    private void Awake()
    {
        pooler = FindObjectOfType<Pooler>();

        SetUpSprite();
        SetUpColor();
    }
    public string GetId()
    {
        return id_Config.GetIdViaSO();
    }

    public string GetObjType()
    {
        return id_Config.GetObjTypeViaSO();
    }

    public void SetUpSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteConfig.GetDefaultSprite();
    }

    public void SetUpColor()
    {
        var dColor = spriteConfig.GetDefaultColor();
        if (dColor != null)
        {
            gameObject.GetComponent<SpriteRenderer>().color = dColor;
        }
    }
}
