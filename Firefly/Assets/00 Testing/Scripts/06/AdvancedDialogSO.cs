using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DialogText", menuName = "Dialog")]
public class AdvancedDialogSO : ScriptableObject
{
    public DialogActors[] actors;

    [Tooltip("Only needed if random is selected as the actor name")]
    [Header("Random Actor Info")]
    public string randomActorName;
    public Sprite randomActorPortrait;


    [Header("Dialog")]
    [TextArea(3, 10)]
    public string[] dialogs;


    [Tooltip("The words that will appear on option buttons")]
    public string[] optionText;


    public AdvancedDialogSO option0;
    public AdvancedDialogSO option1;
    public AdvancedDialogSO option2;
    public AdvancedDialogSO option3;
}
