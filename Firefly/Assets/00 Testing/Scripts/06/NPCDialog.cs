using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public AdvancedDialogSO[] conversations;

    private Transform player;
    private SpriteRenderer speechBubbleRenderer;

    private AdvancedDialogManager advancedDialogManager;
    private bool dialogInitiated = false;


    private void Start()
    {
        advancedDialogManager = GameObject.Find("AdvancedDialogManager").GetComponent<AdvancedDialogManager>();

        speechBubbleRenderer = GetComponent<SpriteRenderer>();
        speechBubbleRenderer.enabled = false;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterController2>() && !dialogInitiated)
        {
            speechBubbleRenderer.enabled = true;

            player = collision.gameObject.GetComponent<Transform>();

            if (player.position.x > transform.position.x && transform.parent.localScale.x < 0)
            {
                Flip();
            }
            else if (player.position.x < transform.position.x && transform.parent.localScale.x > 0)
            {
                Flip();
            }

            advancedDialogManager.InitiateDialog(this);
            dialogInitiated = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterController2>())
        {
            speechBubbleRenderer.enabled = false;

            advancedDialogManager.TurnOffDialog();
            dialogInitiated = false;
        }
    }


    private void Flip()
    {
        Vector3 currentScale = transform.parent.localScale;
        currentScale.x *= -1f;
        transform.parent.localScale = currentScale;
    }
}







