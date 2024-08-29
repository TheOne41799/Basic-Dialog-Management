using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card[] characterCards;

    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI characterDescription;
    [SerializeField] private Image characterPortrait;

    private int characterID = 0;


    private void Start()
    {
        ChangeCard(characterID);
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (characterID == 0)
            {
                characterID = 1;
                ChangeCard(characterID);                
            }
            else
            {
                characterID = 0;
                ChangeCard(characterID);                
            }
        }
    }


    private void ChangeCard(int charID)
    {
        characterName.text = characterCards[charID].characterName;
        characterDescription.text = characterCards[charID].characterDescription;
        characterPortrait.sprite = characterCards[charID].characterPortrait;
    }
}
