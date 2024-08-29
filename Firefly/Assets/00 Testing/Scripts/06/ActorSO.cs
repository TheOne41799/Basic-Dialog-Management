using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Actor", menuName = "Actor SO")]
public class ActorSO : ScriptableObject
{
    public string actorName;
    public Sprite actorPortrait;
}
