using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObject_NoSprite : MonoBehaviour
{
    [SerializeField] Id_Config id_Config;

    public string GetId()
    {
        return id_Config.GetIdViaSO();
    }

    public string GetObjType()
    {
        return id_Config.GetObjTypeViaSO();
    }
}
