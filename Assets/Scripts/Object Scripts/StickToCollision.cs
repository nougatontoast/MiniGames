using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToCollision : MonoBehaviour
{
    [SerializeField] List<GameObject> collidables = new List<GameObject>();
    [SerializeField] List<string> collideTags = new List<string>();

    IdManager idManager;

    private GameObject objStuckTo = null;
    private bool isStuck = new bool();

    private void Awake()
    {
        idManager = FindObjectOfType<IdManager>();
    }

    private void Update()
    {
        if (isStuck)
        {
            transform.position = transform.position + objStuckTo.transform.position;
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
                    objStuckTo = collision.gameObject;
                    isStuck = true;
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
