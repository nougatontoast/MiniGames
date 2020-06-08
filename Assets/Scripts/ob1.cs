using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ob1 : MonoBehaviour
{
    private void Awake()
    {
        var pH = gameObject.GetComponent<Placeholder>();

        pH.Tested1 += Test1;
    }

    private void Test1()
    {
        Debug.Log("ob1 is connected to Tested1 delegate");
    }
}
