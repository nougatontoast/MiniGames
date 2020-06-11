using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsViaBounds : Bounds
{

    IdManager idManager;
    MinigameHandler minigameHandler;

    [Header("References")]
    [SerializeField] internal Pooler pooler = null;

    [Header("Spawn Config")]
    [SerializeField] internal SpawnConfig spawnConfig = null;
    [SerializeField] internal bool spawnInRandomOrder = new bool();

    private List<GameObject> spawnablesList = null;
    private GameObject currentSpawnable = null;
    private int currentSpawnIndex = 0;

    private string spawnObjId = null;
    private string spawnObjType = null;

    private float minDelay = new float();
    private float maxDelay = new float();

    private bool isSpawning = false;
    private Coroutine delaySpawnCoroutine = null;

    private void Awake()
    {
        idManager = FindObjectOfType<IdManager>();
        minigameHandler = FindObjectOfType<MinigameHandler>();

        GetColliderBounds();

        spawnablesList = spawnConfig.GetSpawnablesList();

        minDelay = spawnConfig.GetMinDelay();
        maxDelay = spawnConfig.GetMaxDelay();
    }

    private void Update()
    {
        if (!isSpawning)
        {
            ChooseNextSpawnable();
        }
    }

    private void ChooseNextSpawnable()
    {
        if (spawnInRandomOrder)
        {
            currentSpawnable = spawnablesList[Random.Range(0, spawnablesList.Count)];
            GetSpawnableIdInfo(currentSpawnable);
            SpawnInBounds(spawnObjType, spawnObjId, 1);
        }
        else
        {
            if (currentSpawnIndex <= spawnablesList.Count)
            {
                currentSpawnable = spawnablesList[currentSpawnIndex];
                GetSpawnableIdInfo(currentSpawnable);
                SpawnInBounds(spawnObjType, spawnObjId, 1);
            }
        }
    }

    private void GetSpawnableIdInfo(GameObject spawnable)
    {
        var spawnObj = spawnConfig.GetSpawnable();
        spawnObjId = idManager.GetObjId(spawnObj);
        spawnObjType = idManager.GetObjType(spawnObj);
    }

    private void SpawnInBounds(string id_type_objtospawn, string id_objtospawn, int amountToSpawn)
    {
        isSpawning = true;

        for (int i = 0; i < amountToSpawn; ++i)
        {
            float x = Random.Range(_colliderMin.x, _colliderMax.x);
            float y = Random.Range(_colliderMin.y, _colliderMax.y);

            if (theCollider.OverlapPoint(new Vector2(x, y)))
            {
                Vector3 spawnPos = new Vector3(x, y, 0);
                Debug.Log("Spawning");
                delaySpawnCoroutine = StartCoroutine(DelaySpawn(id_type_objtospawn, id_objtospawn, spawnPos, amountToSpawn));
            }
            else
            {
                isSpawning = false;
                continue;
            }
        }
    }

    private IEnumerator DelaySpawn(string id_type_objtospawn, string id_objtospawn, Vector3 spawnPos, int amountToSpawn)
    {
        float theDelay = Random.Range(minDelay, maxDelay);

        yield return new WaitForSeconds(theDelay);
        pooler.SpawnFromPool(id_type_objtospawn, id_objtospawn, spawnPos, amountToSpawn);
        currentSpawnIndex++;
        isSpawning = false;
        yield break;
    }
}
