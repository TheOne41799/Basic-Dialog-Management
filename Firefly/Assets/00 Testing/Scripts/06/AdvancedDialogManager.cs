using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AdvancedDialogManager : MonoBehaviour
{
    private AdvancedDialogSO currentConversation;
    private int stepNumber;
    private bool dialogActivated = false;

    [SerializeField] private GameObject dialogBoxUI;
    [SerializeField] private TextMeshProUGUI actorName;
    [SerializeField] private Image actorPortrait;
    [SerializeField] private TextMeshProUGUI dialog;

    private string currentSpeakerName;
    private Sprite currentSpeakerSprite;

    public ActorSO[] recurringActorsSO;


    private void Start()
    {
        dialogBoxUI.SetActive(false);
    }


    private void Update()
    {
        if (dialogActivated && Input.GetKeyDown(KeyCode.Space))
        {
            if(stepNumber >= currentConversation.actors.Length)
            {
                TurnOffDialog();
            }
            else
            {
                PlayDialog();
            }
        }
    }


    public void InitiateDialog(NPCDialog npcDialog)
    {
        currentConversation = npcDialog.conversations[0];

        dialogActivated = true;
    }


    public void TurnOffDialog()
    {
        dialogBoxUI.SetActive(false);
        dialogActivated = false;

        stepNumber = 0;
    }


    private void PlayDialog()
    {
        if (currentConversation.actors[stepNumber] == DialogActors.Random)
        {
            SetActorInfo(false);
        }
        else
        {
            SetActorInfo(true);
        }

        actorName.text = currentSpeakerName;
        actorPortrait.sprite = currentSpeakerSprite;

        dialog.text = currentConversation.dialogs[stepNumber];
        dialogBoxUI.SetActive(true);
        stepNumber++;
    }


    private void SetActorInfo(bool recurringActor)
    {
        if (recurringActor)
        {
            for (int i = 0; i < recurringActorsSO.Length; i++)
            {
                if (recurringActorsSO[i].actorName == currentConversation.actors[stepNumber].ToString())
                {
                    currentSpeakerName = recurringActorsSO[i].actorName;
                    currentSpeakerSprite = recurringActorsSO[i].actorPortrait;
                }
            }
        }
        else
        {
            currentSpeakerName = currentConversation.randomActorName;
            currentSpeakerSprite = currentConversation.randomActorPortrait;
        }
    }
}


public enum DialogActors
{
    Dracula,
    InvisibleMan,
    Random,
    Branch
};




