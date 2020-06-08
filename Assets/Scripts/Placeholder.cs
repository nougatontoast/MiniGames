using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeholder : MonoBehaviour
{
    public delegate void OnTest1();
    public event OnTest1 Tested1;

    public delegate void OnTest2();
    public event OnTest1 Tested2;

    private void Start()
    {
        Tested1?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tested2?.Invoke();
            Debug.Log("Invoking tested 2");

            if (Tested2 == null)
            {
                Debug.Log("Tested 2 is null");
            }
        }
    }
}
