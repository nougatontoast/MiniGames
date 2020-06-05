using UnityEngine;

[CreateAssetMenu]
public class ProjConfig : ScriptableObject
{
    [SerializeField] private float projectileSpeed = new float();

    public float GetProjectileSpeed() { return projectileSpeed; }
}
