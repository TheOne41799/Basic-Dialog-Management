using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI actorMessageText;
    public RectTransform dialogBox;

    private Message[] currentMessages;
    private Actor[] currentActors;
    private int activeMessage = 0;

    public static bool isDialogManagerActive = false;


    private void Start()
    {
        dialogBox.transform.localScale = Vector3.zero;
    }


    public void OpenDialog(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isDialogManagerActive = true;

        DisplayMessage();
                
        dialogBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }


    private void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        actorMessageText.text = messageToDisplay.dialog;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.actorName;
        actorImage.sprite = actorToDisplay.actorSprite;

        AnimateTextColor();
    }


    public void NextMessage()
    {
        activeMessage++;

        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            dialogBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isDialogManagerActive = false;
        }
    }


    private void AnimateTextColor()
    {
        Color startColor = actorMessageText.color;
        startColor.a = 0f;
        actorMessageText.color = startColor;

        LeanTween.value(actorMessageText.gameObject, actorMessageText.color.a, 1, 0.8f).setOnUpdate((float value) =>
            {
                Color color = actorMessageText.color;
                color.a = value;
                actorMessageText.color = color;
            });
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDialogManagerActive)
        {
            NextMessage();
        }
    }
}
