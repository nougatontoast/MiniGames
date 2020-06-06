using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLobbyUi : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    [SerializeField] GameObject Life1 = null;
    [SerializeField] GameObject Life2 = null;
    [SerializeField] GameObject Life3 = null;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        if (scoreKeeper.GetCurrentLives() == 3)
        {
            Life1.GetComponent<Image>().enabled = true;
            Life2.GetComponent<Image>().enabled = true;
            Life3.GetComponent<Image>().enabled = true;
        }
        if (scoreKeeper.GetCurrentLives() == 2)
        {
            Life1.GetComponent<Image>().enabled = true;
            Life2.GetComponent<Image>().enabled = true;
            Life3.GetComponent<Image>().enabled = false;
        }
        if (scoreKeeper.GetCurrentLives() == 1)
        {
            Life1.GetComponent<Image>().enabled = true;
            Life2.GetComponent<Image>().enabled = false;
            Life3.GetComponent<Image>().enabled = false;
        }
        if (scoreKeeper.GetCurrentLives() <= 0)
        {
            Life1.GetComponent<Image>().enabled = false;
            Life2.GetComponent<Image>().enabled = false;
            Life3.GetComponent<Image>().enabled = false;
        }
    }

}
