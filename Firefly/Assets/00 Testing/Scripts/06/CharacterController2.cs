using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController2 : MonoBehaviour
{
    public float speed = 8f;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        if (DialogManager.isDialogManagerActive)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(moveX, moveY).normalized;
        rb.velocity = move * speed;
    }
}
