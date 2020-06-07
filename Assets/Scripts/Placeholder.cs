using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeholder : MonoBehaviour
{
    private string testText = null;
    private void Awake()
    {
        Debug.Log("This awake is derived from PLACEHOLDER");
        testText = "Private test text";
    }
}
