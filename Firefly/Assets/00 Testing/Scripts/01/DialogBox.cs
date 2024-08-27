using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    public Transform dialogBoxPanel;
    public CanvasGroup backgroundImageCanvasGrp;


    private void OnEnable()
    {
        backgroundImageCanvasGrp.alpha = 0;
        backgroundImageCanvasGrp.LeanAlpha(1, 0.4f);

        dialogBoxPanel.localPosition = new Vector2(0, -Screen.height);
        dialogBoxPanel.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
    }


    public void CloseDialog()
    {
        backgroundImageCanvasGrp.LeanAlpha(0, 0.2f);
        dialogBoxPanel.LeanMoveLocalY(-Screen.height, 0.4f).setEaseInExpo().setOnComplete(OnComplete);
    }


    private void OnComplete()
    {
        gameObject.SetActive(false);
    }
}
