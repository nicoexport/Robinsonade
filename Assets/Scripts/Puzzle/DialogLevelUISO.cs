using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_DialogLevelUISprites", menuName = "Scriptable Objects/DialogLevelUISprites", order = 0)]
public class DialogLevelUISO : ScriptableObject
{
    public Sprite positiveSprite;
    public Color positiveColor;
    public Sprite neutralSprite;
    public Color neutralColor;
    public Sprite negativeSprite;
    public Color negativeColor;
}
