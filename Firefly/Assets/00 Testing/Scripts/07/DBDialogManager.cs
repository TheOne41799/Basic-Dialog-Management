using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DBDialogManager : MonoBehaviour
{
    private static DBDialogManager instance;
    public static DBDialogManager Instance
    {  
        get 
        { 
            return instance; 
        }
    }


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }


    public GameObject dialogBoxUI;
    public TextMeshProUGUI dialogName;
    public Image dialogPortrait;
    public TextMeshProUGUI dialogText;

    private Queue<DialogBaseSO.Info> dialogInfo = new Queue<DialogBaseSO.Info>();

    public bool isDialogActivated = false;
    public bool canCharacterMove = true;

    private int totalMessages;
    private int activeMessage = 0;

    private bool isTyping = false;
    private bool cancelTyping = false;

    [SerializeField] private float typeWriterDelay = 0.025f;


    private void Start()
    {
        dialogBoxUI.transform.localScale = Vector3.zero;
    }


    private void Update()
    {
        //For animatedTextColorCode
        /*if (Input.GetKeyDown(KeyCode.Space) && isDialogActivated)
        {
            NextDialog();            
        }*/

        if (Input.GetKeyDown(KeyCode.Space) && isDialogActivated)
        {
            if (isTyping)
            {
                cancelTyping = true;
            }
            else
            {
                NextDialog();
            }
        }
    }


    public void EnqueueDialog(DialogBaseSO db)
    {
        dialogInfo.Clear();

        isDialogActivated = true;

        foreach (DialogBaseSO.Info info in db.dialogInfo)
        {
            dialogInfo.Enqueue(info);
        }

        totalMessages = dialogInfo.Count;
        activeMessage = 0;
    }


    public void DequeueDialog()
    {
        DialogBaseSO.Info info = dialogInfo.Dequeue();

        //AnimateTextColor
        /*//dialogName.text = info.myName;
        dialogName.text = info.Character.myName;
        //dialogPortrait.sprite = info.portrait;
        dialogPortrait.sprite = info.Character.myPortrait;
        dialogText.text = info.myText;

        AnimateTextColor();*/


        //Type Write Effect
        //dialogName.text = info.myName;
        dialogName.text = info.character.myName;
        
        //dialogPortrait.sprite = info.portrait;
        dialogPortrait.sprite = info.character.myPortrait;

        StartCoroutine(TypeWriterEffect(info));
    }


    public void NextDialog()
    {
        if (activeMessage == 0)
        {
            dialogBoxUI.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
            canCharacterMove = false;
        }

        if (activeMessage < totalMessages)
        {
            DequeueDialog();
        }
        else
        {
            TurnOffDialog();
        }

        activeMessage++;
    }


    public void TurnOffDialog()
    {
        dialogBoxUI.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();

        isDialogActivated = false;
        canCharacterMove = true;
    }

    /*private void AnimateTextColor()
    {
        Color startColor = dialogText.color;
        startColor.a = 0f;
        dialogText.color = startColor;

        LeanTween.value(dialogText.gameObject, dialogText.color.a, 1, 0.8f).setOnUpdate((float value) =>
        {
            Color color = dialogText.color;
            color.a = value;
            dialogText.color = color;
        });
    }*/


    //Simple type writer effect
    private IEnumerator TypeWriterEffect(DialogBaseSO.Info info)
    {
        isTyping = true;
        dialogText.text = "";
        cancelTyping = false;

        foreach(char letter in info.myText.ToCharArray())
        {
            if(cancelTyping)
            {
                dialogText.text = info.myText;
                break;
            }

            dialogText.text += letter;
            AudioManager.Instance.PlayClip(info.character.myVoice);

            yield return new WaitForSeconds(typeWriterDelay);
        }

        isTyping = false;
    }
}








