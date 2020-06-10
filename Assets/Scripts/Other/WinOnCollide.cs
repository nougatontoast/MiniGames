using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOnCollide : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string typetag in collideTags)
        {
            var thisType = idManager.GetObjType(collision.gameObject);

            if (thisType != null)
            {
                if (thisType.Equals(typetag))
                {
                    minigameHandler.InvokePlayerWon();
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

