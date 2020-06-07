using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    IdManager idManager;
    Pooler pooler;

    [SerializeField] List<GameObject> shreddables = new List<GameObject>();
    [SerializeField] List<string> shredTags = new List<string>();

    private void Awake()
    {
        idManager = FindObjectOfType<IdManager>();
        pooler = FindObjectOfType<Pooler>();

        foreach (GameObject obj in shreddables)
        {
            shredTags.Add(idManager.GetObjType(obj));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string typetag in shredTags)
        {
            var thisType = idManager.GetObjType(collision.gameObject);

            if (thisType.Equals(typetag))
            {
                pooler.ReturnToPool(collision.gameObject);
            }
            else
            {
                Debug.Log("Type does not match shredder");
            }
        }
    }
}
