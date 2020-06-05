using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour, IId, IInteract, ICancelInteract
{
    [SerializeField] internal Id_Config id_Config = null;

    #region ID and Type getters
    public string GetId()
    {
        return id_Config.GetIdViaSO();
    }

    public string GetObjType()
    {
        return id_Config.GetObjTypeViaSO();
    }
    #endregion

    public virtual void Interact()
    {
    }

    public virtual void CancelInteract()
    {
    }

}
