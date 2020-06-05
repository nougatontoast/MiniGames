using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Internal Ref")]
    [SerializeField] internal Movement movement = null;
    [SerializeField] internal PInput pInput = null;
    [SerializeField] internal pInteract pInteract = null;
    [SerializeField] internal Rigidbody2D rb = null;



    [Header("Other Player")]
    [SerializeField] internal Player otherPlayer = null;
    internal void Awake()
    {
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        
    }
}