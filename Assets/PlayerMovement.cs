using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    //param
    public float moveForce = 50f;

    //state
    Vector2 moveInput = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ListenForKeyboard();
        Debug.DrawLine(transform.position, transform.position + (Vector3)moveInput, Color.blue);
        Debug.DrawLine(transform.position, transform.position + (Vector3)rb.velocity, Color.green);
    }

    private void ListenForKeyboard()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(horiz) > Mathf.Epsilon)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                moveInput.x = 1;
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                moveInput.x = -1;
            }
        }
        else
        {
            moveInput.x = 0;
        }

        if (Mathf.Abs(vert) > Mathf.Epsilon)
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                moveInput.y = 1;
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                moveInput.y = -1;
            }
        }
        else
        {
            moveInput.y = 0;
        }

    }

    private void FixedUpdate()
    {
        rb.AddForce(moveInput * moveForce, ForceMode2D.Impulse);

    }
}
