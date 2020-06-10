using UnityEngine;

public abstract class Bounds : MonoBehaviour, IUseBounds
{
    [SerializeField] internal Collider2D theCollider = new Collider2D();

    internal Vector3 spawnCenter = new Vector3();
    internal Vector3 _colliderSize = new Vector3();
    internal Vector3 _colliderMin = new Vector3();
    internal Vector3 _colliderMax = new Vector3();

    // Start is called before the first frame update
    void Awake()
    {
        GetColliderBounds();
    }

    private void GetColliderBounds()
    {
        spawnCenter = theCollider.bounds.center;
        _colliderSize = theCollider.bounds.size;
        _colliderMin = theCollider.bounds.min;
        _colliderMax = theCollider.bounds.max;

        Debug.Log(_colliderMin);
        Debug.Log(_colliderMax);
    }

    public virtual void UseBounds(Vector3 spawnCenter, Vector3 _colliderSize, Vector3 _colliderMin, Vector3 _colliderMax)
    {

    }
}
