using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    float horizontalInput;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    bool isGrounded;
    private int jumpCount;
    public int maxJumps = 2;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);

        // Flip the sprite
        Flip(horizontalInput);

        CheckGrounded();

        if (isGrounded)
        {
            jumpCount = maxJumps;
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount --;
        }

        // Ground check
        CheckGrounded();
    }

    private void Flip(float velocity)
    {
        if (velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void CheckGrounded()
    {
        // A small circle under the player to detect ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
}
