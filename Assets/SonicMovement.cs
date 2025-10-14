using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SonicMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 10f;

    [Header("Visuals")]
    [SerializeField] private GameObject standVisual;  // block
    [SerializeField] private GameObject jumpVisual;

    private Rigidbody2D rb;
    private float moveHorz;
    private float moveUp;
    private bool jumpPressed;       // pressed this frame
    // private bool isGrounded;

    private void Awake()
    {
        jumpPressed = false;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        SetVisual(isJumping: false);
    }

    private void Update()
    {
        // Basic left/right (A/D or arrows)
        moveHorz = Input.GetAxisRaw("Horizontal");
        moveUp = Input.GetAxisRaw("Vertical");
        // Jump on press (not hold)
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }

    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(moveHorz * moveSpeed, rb.velocity.y);

        // Jump only if grounded
        if (jumpPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveUp * jumpForce);
            jumpPressed = false;
        }

        // consume the press
        bool ascending = rb.velocity.y > 0.01f;
        SetVisual(isJumping: ascending);

    }
    
    private void SetVisual(bool isJumping)
    {
        if (standVisual) standVisual.SetActive(!isJumping);
        if (jumpVisual)  jumpVisual.SetActive(isJumping);
    }
}
