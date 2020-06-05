using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    IdManager idManager;

    [Header("Call Lists")]
    [SerializeField] private List<PoolerCallList> allLists = null;
    [SerializeField] private List<Transform> poolerContainers = new List<Transform>();

    private List<GameObject> tempGameObjectList = new List<GameObject>();
    internal List<GameObject> objectToReturn = new List<GameObject>();

    void Awake()
    {
        idManager = FindObjectOfType<IdManager>();

        TransferObjsFromCallListToPoolerList();
        CreateObjsOnList();
        DeactivateAllObjectsInPools();
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = transform.position;

        objectToReturn.Remove(obj);
    }


    private void TransferObjsFromCallListToPoolerList()
    {
        foreach (PoolerCallList list in allLists)
        {
            var currentCallList = list;

            foreach (ItemAmountForPool item in currentCallList.GetListofPrefabs())
            {
                for (int i = 0; i < item.NumberToInst; i++)
                {
                    tempGameObjectList.Add(item.ObjectToPool);
                }
            }
        }
    }

    private void CreateObjsOnList()
    {
        foreach (GameObject prefab in tempGameObjectList)
        {
            string calledForLocation = prefab.GetComponent<IId>().GetObjType();

            Transform myContainer = null;
            foreach (Transform container in poolerContainers)
            {
                if (calledForLocation.Equals(container.name))
                {
                    myContainer = container;
                }
            }
            Instantiate(prefab, myContainer);
        }
    }

    private void DeactivateAllObjectsInPools()
    {
        foreach (Transform container in poolerContainers)
        {
            foreach (Transform child in container)
            {
                child.gameObject.SetActive(false);
            }
        }

        tempGameObjectList = null;
    }

    #region Aimed Obj
    /*    public void SpawnObjInPool(string containerName, string id, AimLocation aimer, Vector3 pos, float angle, int spawnNumber)
        {
            Debug.Log(spawnNumber);
            var spawnNumTemp = 0;
            Debug.Log(spawnNumTemp);

            foreach (Transform container in poolerContainers)
            {
                if (container.name.Equals(containerName))
                {
                    Debug.Log("Called for: " + containerName);
                    Debug.Log("Found: " + container.name);

                    tempContainerRef = container;
                }

                foreach (Transform child in tempContainerRef)
                {
                    if (spawnNumTemp != spawnNumber)
                    {
                        if (id.Equals(child.GetComponent<IId>().GetId()))
                        {
                            if (!child.gameObject.activeInHierarchy)
                            {
                                child.gameObject.transform.position = pos;
                                child.gameObject.transform.localRotation = Quaternion.Euler(0f, angle + 50f, 0f);
                                child.gameObject.SetActive(true);

                                IBelongTo belongTo = child.GetComponent<IBelongTo>();

                                if (belongTo != null)
                                {
                                    belongTo.SetOwner(aimer);
                                }

                                spawnNumTemp++;
                                Debug.Log("Spawnnumtemp: " + spawnNumTemp);
                            }
                        }
                    }
                    else if (spawnNumTemp == spawnNumber)
                    {
                        continue;
                    }
                }
            }
        }*/
    #endregion

    public void SpawnFromPool(string containerName, string id, Vector3 pos, int spawnNumber)
    {
        var spawnNumTemp = 0;

        foreach (Transform container in poolerContainers)
        {

            if (container.name.Equals(containerName))
            {
                var theContainer = container;

                foreach (Transform child in theContainer)
                {
                    if (spawnNumTemp != spawnNumber)
                    {
                        var childId = idManager.GetObjId(child.gameObject);

                        if (id.Equals(childId))
                        {
                            if (!child.gameObject.activeInHierarchy)
                            {
                                child.gameObject.transform.position = pos;
                                child.gameObject.SetActive(true);

                                spawnNumTemp++;
                            }
                        }
                    }
                    else if (spawnNumTemp == spawnNumber)
                    {
                        continue;
                    }
                }
            }
        }
    }
}
