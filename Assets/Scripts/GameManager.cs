using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] internal GameStartUi gameStartUi = null;

    private bool gameStarted = false;

    private int maxCount = 3;
    internal int currentCount = new int();

    private void Awake()
    {
        currentCount = maxCount;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if (currentCount != 0)
        {
            StartCoroutine(DelayCount(2));
        }

        if (currentCount == 1)
        {
            gameStarted = true;
        }
    }

    public IEnumerator DelayCount(int delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameStartUi.UpdateCountText(currentCount);
        currentCount--;
        yield break;
    }

}
