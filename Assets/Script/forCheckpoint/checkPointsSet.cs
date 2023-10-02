using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetCheckpoint(other.gameObject);
        }
    }

    private void SetCheckpoint(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.SetRespawnPosition(transform.position);
            Debug.Log("Checkpoint set!");
        }
    }
}