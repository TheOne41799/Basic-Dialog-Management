using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation / Dialogs")]
public class DialogBaseSO : ScriptableObject
{
    [Header("Insert dialog information here")]
    public Info[] dialogInfo;


    [System.Serializable]
    public class Info
    {
        public CharacterProfile character;
        //public string myName;
        //public Sprite portrait;

        [TextArea(3, 10)]
        public string myText;
    }    
}
