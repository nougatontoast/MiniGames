using System.Collections.Generic;
using UnityEngine;

public class LoseOnCollide : MonoBehaviour
{
    IdManager idManager = null;
    MinigameHandler minigameHandler = null;

    [SerializeField] List<GameObject> collidables = new List<GameObject>();
    [SerializeField] List<string> collideTags = new List<string>();

    private void Awake()
    {
        idManager = FindObjectOfType<IdManager>();
        minigameHandler = FindObjectOfType<MinigameHandler>();

        foreach (GameObject obj in collidables)
        {
            collideTags.Add(idManager.GetObjType(obj));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (string typetag in collideTags)
        {
            var thisType = idManager.GetObjType(collision.gameObject);

            if (thisType != null)
            {
                if (thisType.Equals(typetag))
                {
                    minigameHandler.InvokePlayerLost();
                }
                else
                {
                    Debug.Log($"Looking for: {typetag}, Collided with: {thisType}");
                }
            }
            else
            {
                Debug.Log("Collision IID is null");
            }
        }
    }
}

