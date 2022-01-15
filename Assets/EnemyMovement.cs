using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;

    //param
    public float moveForce = 0.2f;

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
        Debug.DrawLine(transform.position, transform.position + (Vector3)rb.velocity, Color.green);
    }   

    private void FixedUpdate()
    {
        rb.AddForce(moveInput * moveForce, ForceMode2D.Impulse);

    }

    public void SetInput(Vector2 newInput)
    {
        moveInput = newInput;
    }
}
