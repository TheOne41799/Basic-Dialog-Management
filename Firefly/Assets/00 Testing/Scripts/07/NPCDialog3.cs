using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog3 : MonoBehaviour
{
    public DialogBaseSO dialog;

    private Transform player;
    private SpriteRenderer speechBubbleRenderer;

    private bool isDialogInitiated = false;


    private void Start()
    {
        speechBubbleRenderer = GetComponent<SpriteRenderer>();
        speechBubbleRenderer.enabled = false;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterController3>() && !isDialogInitiated)
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

            DBDialogManager.Instance.EnqueueDialog(dialog);
            isDialogInitiated = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterController3>())
        {
            speechBubbleRenderer.enabled = false;
            isDialogInitiated = false;
        }
    }


    private void Flip()
    {
        Vector3 currentScale = transform.parent.localScale;
        currentScale.x *= -1f;
        transform.parent.localScale = currentScale;
    }
}





