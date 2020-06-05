using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] internal GameStartUi gameStartUi = null;

    public bool gameStarted = false;

    private int maxCount = 3;
    internal int currentCount = new int();
    private bool isCounting = false;

    public bool playerHasWon = false;
    public bool playerHasLost = false;

    private void Awake()
    {
        currentCount = maxCount;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if (currentCount >= 0)
        {
            if (!isCounting)
            {
                isCounting = true;
                StartCoroutine(DelayCount(.5f));
            }
        }

        if (currentCount == 0)
        {
            gameStarted = true;
            gameStartUi.HidePreStartUI();
        }
    }

    public IEnumerator DelayCount(float delayTime)
    {
        gameStartUi.UpdateCountText(currentCount);
        yield return new WaitForSeconds(delayTime);
        currentCount--;
        isCounting = false;
        yield break;
    }

}
