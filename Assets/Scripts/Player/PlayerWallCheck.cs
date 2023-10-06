using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallCheck : MonoBehaviour
{
    public LayerMask groundLayer; // Set this to the layer containing your ground tiles
    public float wallSlideForce = 1f; // Adjust the force to control wall sliding

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool isMidair = !IsGrounded();

        // Wall sliding when in midair and in contact with a wall
        if (isMidair && IsTouchingWall())
        {
            rb.velocity = new Vector2(rb.velocity.x, -wallSlideForce);
        }
    }

    bool IsGrounded()
    {
        // Check if the character is grounded
        return Physics2D.OverlapCircle(transform.position, 0.2f, groundLayer);
    }

    bool IsTouchingWall()
    {
        // Cast a ray horizontally to detect walls
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, 0.5f, groundLayer);
        return hit.collider != null;
    }
}
