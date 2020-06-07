using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdManager : MonoBehaviour
{
    public string GetObjId(GameObject obj)
    {
        IId id = obj.GetComponent<IId>();
        if (id != null)
        {
            return id.GetId();
        }
        else
        {
            Debug.Log("ID is Null");
            return null;
        }
    }

    public string GetObjType(GameObject obj)
    {
        IId id = obj.GetComponent<IId>();
        if (id != null)
        {
            return id.GetObjType();
        }
        else
        {
            Debug.Log("Object type is Null");
            return null;
        }
    }
}
