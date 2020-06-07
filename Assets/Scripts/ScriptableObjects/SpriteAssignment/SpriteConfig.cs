using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpriteConfig : ScriptableObject
{
    [SerializeField] Sprite defaultSprite = null;
    [SerializeField] Sprite winSprite = null;
    [SerializeField] Sprite lostSprite = null;

    [SerializeField] Color defaultColor = new Color();

    public Sprite GetDefaultSprite() { return defaultSprite; }
    public Color GetDefaultColor() { return defaultColor; }
    public Sprite GetWinSprite() { return winSprite; }
    public Sprite GetLostSprite() { return lostSprite; }
}
