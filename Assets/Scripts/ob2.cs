using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ob2 : MonoBehaviour
{
    private void Awake()
    {
        var pH = gameObject.GetComponent<Placeholder>();

        pH.Tested2 += Test2;
    }

    private void Test2()
    {
        Debug.Log("ob2 is connected to Tested2 delegate");
    }
}
