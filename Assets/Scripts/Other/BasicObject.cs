﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicObject : MonoBehaviour, IId
{
    [SerializeField] Id_Config id_Config = null;
    [SerializeField] SpriteConfig spriteConfig = null;

    private void Awake()
    {
        SetUpSprite();
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
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteConfig.GetSprite();
    }
}
