using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public Transform launcherTransform;
    public GameObject bulletPrefab;
    public AudioClip rocketLaunchSFX;
    public float bulletSpeed = 10f;
    public float fireRate = 0.2f;
    public float nextFireTime = 0f;

    private AudioSource playerAudioSource;
    private float resetInterval = 300f; // Reset the timer every 5 minutes, to avoid gradual floating point precision loss

    private void Awake()
    {
        playerAudioSource = GetComponent<AudioSource>();
        playerAudioSource.clip = rocketLaunchSFX;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            ShootRocket();
        }

        RotateLauncher();

        ResetCooldown();
    }

    private void ResetCooldown()
    {
        if (Time.time >= nextFireTime + resetInterval)
        {
            nextFireTime = Time.time + fireRate;
        }
    }

    private void RotateLauncher()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(
            mousePosition.y - launcherTransform.position.y,
            mousePosition.x - launcherTransform.position.x
        ) * Mathf.Rad2Deg;

        launcherTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void ShootRocket()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the shooting point to the mouse cursor
        Vector2 direction = (mousePosition - transform.position).normalized;
        direction.Normalize();

        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, launcherTransform.position, Quaternion.identity);

        // Play SFX
        playerAudioSource.Play();

        // Apply the calculated direction as the initial velocity
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        Debug.Log("Direction: " + direction);
        Debug.Log("Direction + Speed: " + direction * bulletSpeed);

        // Update the next allowed shot time
        nextFireTime = Time.time + fireRate;
    }
}
