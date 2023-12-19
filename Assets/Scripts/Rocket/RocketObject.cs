using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RocketObject : MonoBehaviour
{
    [Header("Explosion")]
    public GameObject explosionPrefab;    // Reference to the explosion prefab
    public AudioClip rocketBlastSFX;
    public float explosionForce = 10f;    // Force of the explosion
    public float explosionRadius = 2f;    // Radius of the explosion
    public float explosionDuration = 1f;

    private CinemachineImpulseSource impulseSource;
    private AudioSource rocketSource;
    private SpriteRenderer rocketRenderer;
    private CircleCollider2D circleCollider;

    private void Awake()
    {
        rocketSource = GetComponent<AudioSource>();
        rocketSource.clip = rocketBlastSFX;

        impulseSource = GetComponent<CinemachineImpulseSource>();

        rocketRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

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

            // Shake camera
            CameraShakeManager.instance.CameraShake(impulseSource);

            // Hide bullet first before making sound
            rocketRenderer.enabled = false;
            circleCollider.enabled = false;

            // Destroy the bullet when it collides with a wall
            StartCoroutine(MakeSoundThenDie());
        }
    }
    private void CreateExplosion(Vector2 position)
    {
        GameObject explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        //rocketSource.Play();
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

    private IEnumerator MakeSoundThenDie()
    {
        float clipLength = rocketBlastSFX.length;
        rocketSource.Play();

        yield return new WaitForSeconds(clipLength);

        Destroy(gameObject);
    }
}
