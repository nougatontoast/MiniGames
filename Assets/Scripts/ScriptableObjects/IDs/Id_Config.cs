using UnityEngine;

[CreateAssetMenu]
public class Id_Config : ScriptableObject
{
    [SerializeField] private string id = null;
    [SerializeField] private string objType = null;

    public string GetIdViaSO() { return id; }
    public string GetObjTypeViaSO() { return objType; }
}
