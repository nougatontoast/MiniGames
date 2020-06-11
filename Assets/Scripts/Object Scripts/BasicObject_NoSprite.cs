using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObject_NoSprite : MonoBehaviour, IId
{
    [SerializeField] Id_Config id_Config = null;

    public string GetId()
    {
        return id_Config.GetIdViaSO();
    }

    public string GetObjType()
    {
        return id_Config.GetObjTypeViaSO();
    }
}
