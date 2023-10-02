using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketObject : MonoBehaviour
{
    public GameObject explosionPrefab;    // Reference to the explosion prefab
    public float explosionForce = 10f;    // Force of the explosion
    public float explosionRadius = 2f;    // Radius of the explosion
    public float explosionDuration = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet collided with a wall
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Get destroyed");
            // Play particle effects
            CreateExplosion(transform.position);

            // Apply force to surrounding rigidbodies
            PushObjectsInRadius(transform.position);

            // Destroy the bullet when it collides with a wall
            Destroy(gameObject);
        }
    }
    private void CreateExplosion(Vector2 position)
    {
        GameObject explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        Destroy(explosion, explosionDuration); // Destroy the explosion after 1 second (adjust as needed)
    }

    private void PushObjectsInRadius(Vector2 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // Calculate the direction from the explosion center to the object
                Vector2 direction = (rb.position - position).normalized;

                // Apply force to the object
                rb.AddForce(direction * explosionForce, ForceMode2D.Impulse);
            }
        }
    }
}
