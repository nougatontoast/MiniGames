using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnCollide : MinigameHandler
{
    IdManager idManager = null;

    [SerializeField] List<GameObject> collidables = new List<GameObject>();
    [SerializeField] List<string> collideTags = new List<string>();

    private void Awake()
    {
        idManager = FindObjectOfType<IdManager>();

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
                    PlayerLostTrue();
                }
                else
                {
                    Debug.Log("Collision does not match");
                }
            }
            else
            {
                Debug.Log("Collision coming back null");
            }
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
                    PlayerLostTrue();
                }
                else
                {
                    Debug.Log("Collision does not match");
                }
            }
            else
            {
                Debug.Log("Collision coming back null");
            }
        }
    }
}

