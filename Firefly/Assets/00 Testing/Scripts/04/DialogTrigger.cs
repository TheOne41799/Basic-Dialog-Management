using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;


    public void StartDialog()
    {
        FindObjectOfType<DialogManager>().OpenDialog(messages, actors);
    }
}


[System.Serializable]
public class Message
{
    public int actorID;
    public string dialog;
}


[System.Serializable]
public class Actor
{
    public string actorName;
    public Sprite actorSprite;
}





