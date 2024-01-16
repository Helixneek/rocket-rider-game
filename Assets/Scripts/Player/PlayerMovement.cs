using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;            // Player movement speed.
    public float jumpForce = 7f;            // Jump force.
    public AudioClip landingSound;

    private bool isGrounded;                // Check if the player is grounded.
    private bool isJumping;                 // Check if the player is midair.
    private bool wasGrounded;
    private Rigidbody2D rb;
    private Animator animator;              // Optional: If you want to use animations.
    private AudioSource audioSource;

    // Variables for movement disablement
    private bool isMovementEnabled = true;   // Check if player movement is enabled.
    private float movementDisableDuration = 2.0f;  // Duration of movement disablement.
    private float movementDisableTimer = 0.0f;     // Timer for movement disablement.

    private Vector3 respawnPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Optional: Attach an Animator component if you want to use animations.
        audioSource = GetComponent<AudioSource>();

        respawnPosition = transform.position;
    }

    public void SetRespawnPosition(Vector3 position)
    {
        respawnPosition = position;
    }
    void Update()
    {
        // Check if the player is grounded.
        isGrounded = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 1f), 0.75f, LayerMask.GetMask("Floor"));

        // Check if movement is disabled, and count down the timer.
        if (!isMovementEnabled)
        {
            movementDisableTimer -= Time.deltaTime;

            // If the timer reaches zero, enable movement.
            if (movementDisableTimer <= 0)
            {
                EnableMovement();
            }
        }

        // Horizontal movement (only if movement is enabled).
        if (isMovementEnabled)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }

        // Optional: Set animator parameters for animations.
        if (animator != null)
        {
            //animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            //animator.SetBool("IsGrounded", isGrounded);
        }

        // Jumping (only if movement is enabled and the player is grounded).
        if (isMovementEnabled && isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }

        // Check for landing animation
        if (wasGrounded && !isGrounded)
        {
            // Player was grounded in the previous frame and is not grounded now (just jumped)
            isJumping = true;
        }

        if (isGrounded && isJumping)
        {
            LandingAnimation();
            isJumping = false;
        }

        wasGrounded = isGrounded; // Update the previous grounded state
    }

    // Method to disable player movement for a specified duration.
    public void DisableMovementForDuration(float duration)
    {
        if (isMovementEnabled)
        {
            isMovementEnabled = false;
            movementDisableDuration = duration;
            movementDisableTimer = duration;
        }
    }

    // Method to enable player movement.
    private void EnableMovement()
    {
        isMovementEnabled = true;
    }
    
    public void FreezePosition()
    {
        rb.velocity = Vector2.zero;
    }

    private void LandingAnimation()
    {
        animator.SetTrigger("JustLanded");
        Debug.Log("just landed");
    }

    private void LandingSound()
    {
        audioSource.clip = landingSound;
        audioSource.Play();
    }

    // This shit for testing nigga
    //void OnDrawGizmosSelected()
    //{
    //    // Draw a yellow sphere at the transform's position
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y - 1f), 0.75f);
    //}
}