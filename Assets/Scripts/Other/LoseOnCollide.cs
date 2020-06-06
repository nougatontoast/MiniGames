using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnCollide : MonoBehaviour
{
    GameManager gameManager = null;
    IdManager idManager = null;

    [SerializeField] List<GameObject> collidables = new List<GameObject>();
    [SerializeField] List<string> collideTags = new List<string>();

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        idManager = FindObjectOfType<IdManager>();

        foreach (GameObject obj in collidables)
        {
            collideTags.Add(idManager.GetObjType(obj));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameManager.gameOver)
        {
            foreach (string typetag in collideTags)
            {
                var thisType = idManager.GetObjType(collision.gameObject);

                if (thisType != null)
                {
                    if (thisType.Equals(typetag))
                    {
                        Debug.Log("Player has lost");
                        gameManager.playerHasLost = true;
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
       
}

