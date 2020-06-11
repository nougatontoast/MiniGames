using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjAtPoint : MonoBehaviour
{
    [SerializeField] Transform spawnPoint = null;

    IdManager idManager;
    MinigameHandler minigameHandler;

    [Header("References")]
    [SerializeField] internal Pooler pooler = null;

    [Header("Spawn Config")]
    [SerializeField] internal SpawnConfig spawnConfig = null;

    private List<GameObject> spawnablesList = null;

/*    private int currentSpawnablesNum = 0;*/
/*    private int maxSpawnables = new int();*/

    private string spawnObjId = null;
    private string spawnObjType = null;

    private float minDelay = new float();
    private float maxDelay = new float();

    private bool isSpawning = false;

    private void Awake()
    {
        idManager = FindObjectOfType<IdManager>();
        minigameHandler = FindObjectOfType<MinigameHandler>();

        spawnablesList = spawnConfig.GetSpawnablesList();

        minDelay = spawnConfig.GetMinDelay();
        maxDelay = spawnConfig.GetMaxDelay();

        PickSpawnablesAtRandom();
    }

    private void Update()
    {
        SpawnObjFromPool();
    }

    private void PickSpawnablesAtRandom()
    {
        var theObj = spawnablesList[Random.Range(0, spawnablesList.Count)];
        IId id = theObj.GetComponent<IId>();
        if (id != null)
        {
            spawnObjId = id.GetId();
            spawnObjType = id.GetObjType();
        }
    }

    private void SpawnObjFromPool()
    {
        if (!isSpawning)
        {
            StartCoroutine(DelaySpawn(spawnObjType, spawnObjId, spawnPoint.position, 1));
        }
    }

    private IEnumerator DelaySpawn(string id_type_objtospawn, string id_objtospawn, Vector3 spawnPos, int amountToSpawn)
    {
        isSpawning = true;
        float theDelay = Random.Range(minDelay, maxDelay);

        yield return new WaitForSeconds(theDelay);
        pooler.SpawnFromPool(id_type_objtospawn, id_objtospawn, spawnPos, amountToSpawn);

        isSpawning = false;
        PickSpawnablesAtRandom();
        yield break;
    }
}
