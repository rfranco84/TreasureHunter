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

        float yVel = rb.velocity.y;
        rb.velocity = new Vector2(xVel, yVel);

        
    }

    void flip()
    {
        // Make character face different direction.
    }
}
