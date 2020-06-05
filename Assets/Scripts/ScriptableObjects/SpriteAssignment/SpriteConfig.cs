using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpriteConfig : ScriptableObject
{
    [SerializeField] Sprite defaultSprite = null;
    [SerializeField] Sprite winSprite = null;
    [SerializeField] Sprite lostSprite = null;

    public Sprite GetDefaultSprite() { return defaultSprite; }
    public Sprite GetWinSprite() { return winSprite; }
    public Sprite GetLostSprite() { return lostSprite; }
}
