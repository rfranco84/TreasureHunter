using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float acceleration;
    public float maxSpeed;
    public Rigidbody2D rb;
    public bool faceRight;
    private bool buttonPressed;
    private bool jumpButton;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // receive input. 
        PlayerMove();
    }

    void PlayerMove()
    {

        // Horizontal Movement
        float xVel = Input.GetAxis("Horizontal") * acceleration * Time.smoothDeltaTime + +rb.velocity.x;
        if(xVel>maxSpeed||xVel<maxSpeed*-1)
        {
            xVel = maxSpeed*Input.GetAxis("Horizontal");
        }
        if((faceRight && Input.GetAxis("Horizontal") <0) ||(!faceRight && Input.GetAxis("Horizontal")>0))
         {
            flip();
        }

        // Implement Jump
        // Check if grounded.
        jumpButton = Input.GetButton("Jump");
        if (jumpButton)
            buttonPressed = true;

        if(isGrounded())
        {
            // Can jump if jump button hasn't been held from previous frames.
            if (!jumpButton)
                buttonPressed = false;
            
        }

        float yVel = rb.velocity.y;
        
        rb.velocity = new Vector2(xVel, yVel);

        
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y-gameObject.GetComponent<CapsuleCollider2D>().size.y/2-0.01f), Vector2.down, 0.02f);
        if(hit.collider!=null)
        {
            if(hit.collider.gameObject.tag.Equals("Ground"))
            {
                return true;
            }
        }
        return false;
    }

    void flip()
    {
        // Make character face different direction.
    }
}
