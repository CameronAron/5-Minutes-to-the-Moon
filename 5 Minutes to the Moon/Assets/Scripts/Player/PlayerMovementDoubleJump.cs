using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDoubleJump : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 6f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public KeyCode jumpKey = KeyCode.Space;

    Rigidbody2D rb;
    bool isGrounded;
    bool isGrounded2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        if (isGrounded) 
        {
            isGrounded2 = true;
        }

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (Input.GetKeyDown(jumpKey) && isGrounded2 && DoubleJumpManager.canDoubleJump == true) 
        {
            isGrounded2 = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
