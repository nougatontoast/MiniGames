using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TextConfig : ScriptableObject
{
    [SerializeField] private string text = null;
    
    public string GetText() { return text; }
}
