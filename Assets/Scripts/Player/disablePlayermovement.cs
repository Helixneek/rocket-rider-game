using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class PortalScript : MonoBehaviour
{
    public float disableDuration = 2.0f; // Adjust this to the duration you want the movement to be disabled when hitting the portal

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
            RocketLauncher rocketLauncher = collision.GetComponent<RocketLauncher>();

            if (playerMovement != null)
            {
                playerMovement.enabled = false;
                playerMovement.FreezePosition();
                rocketLauncher.enabled = false;
            }
        }
    }
}





