/*
 * Ronnie Keating
 * Demo Success Script for my level
 *
 *
 *
 */

using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class RonnieDemo : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rb;
    private bool buttonPressed;
    private bool isGround;
    private PlayerController2D ascript;
    private RonnieDemo bscript;
    [SerializeField] Transform groundCheck;
    private StreamReader input;
    private string text;
    private bool isClosed;


    // Start is called before the first frame update
    void Start()
    {
        input = new StreamReader(Application.dataPath + "/5-Ronnie/TextFiles/RonnieDemo.txt");
        rb = GetComponent<Rigidbody2D>();
        ascript = GetComponent<PlayerController2D>();
        bscript = GetComponent<RonnieDemo>();
        ascript.enabled = false;
        bscript.enabled = true;
        buttonPressed = false;
        speed = 4f;
        isClosed = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        if (Input.anyKey && buttonPressed == false) {
            ascript.enabled = true;
            bscript.enabled = false;
            buttonPressed = true;
            Debug.Log("Button Pressed");
        }

        if (!isClosed)
        {
            text = input.ReadLine();
            if (text == "right")
                rb.velocity = new Vector2(speed, rb.velocity.y);
            else if (text == "up" && isGround)
                rb.velocity = new Vector2(rb.velocity.x, 9.5f);
            else if (text == "left")
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            else if (text == "stop")
                rb.velocity = new Vector2(0, rb.velocity.y);
            else if (text == "close")
                isClosed = true;
        }
        if (rb.position.y < -3f)
        {
            transform.position = new Vector2(-8, -1);
        }

        if (rb.position.x > 92)
            rb.velocity = new Vector2(0, 0);

        if (isClosed)
            input.Close();

    }
}