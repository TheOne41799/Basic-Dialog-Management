using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string characterName;

    [TextArea(3, 10)]
    public string characterDescription;

    public Sprite characterPortrait;
}
