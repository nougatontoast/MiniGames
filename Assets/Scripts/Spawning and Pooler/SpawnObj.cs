using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : Bounds
{
    IdManager idManager;
    GameManager gameManager;

    [Header("References")]
    [SerializeField] internal Pooler pooler = null;

    [Header("Spawn Config")]
    [SerializeField] internal SpawnConfig spawnConfig = null;

    internal int currentSpawnablesNum = 0;
    internal int maxSpawnables = new int();

    internal string spawnObjId = null;
    internal string spawnObjType = null;

    internal float minDelay = new float();
    internal float maxDelay = new float();

    private bool isSpawning = false;
    internal Coroutine delaySpawnCoroutine = null;

    private void Awake()
    {
        idManager = FindObjectOfType<IdManager>();
        gameManager = FindObjectOfType<GameManager>();


        var spawnObj = spawnConfig.GetSpawnable();
        spawnObjId = idManager.GetObjId(spawnObj);
        spawnObjType = idManager.GetObjType(spawnObj);

        maxSpawnables = spawnConfig.GetMaxSpawnables();

        minDelay = spawnConfig.GetMinDelay();
        maxDelay = spawnConfig.GetMaxDelay();
    }

    private void Update()
    {
      /*  if (currentSpawnablesNum < maxSpawnables && !isSpawning && gameManager.gameStarted && !gameManager.gameOver)
        {
            SpawnInBounds(spawnObjType, spawnObjId, 1);
        }*/
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
        currentSpawnablesNum++;
        isSpawning = false;
        yield break;
    }
}
