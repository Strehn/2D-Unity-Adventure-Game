using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Rigidbody2D rb;
    private float speed;

    bool isGround;

    [SerializeField]
    Transform groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 4f;
    }

    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
        }
        else if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey("up") && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 9.5f);
        }

        if(rb.position.y < -3f)
        {
            transform.position = new Vector2(-8, -1);
        }
    }
}
