using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpriteConfig : ScriptableObject
{
    [SerializeField] Sprite defaultSprite = null;

    public Sprite GetSprite() { return defaultSprite; }
}
