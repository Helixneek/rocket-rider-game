using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneCheckpoint : MonoBehaviour
{
    public Transform playerStartPosition; // Assign the player's starting position in the Inspector
    private GameObject player;

    private void Awake()
    {
        // Find the player GameObject if it's not already set
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (player != null && playerStartPosition != null)
        {
            TeleportPlayer(player, playerStartPosition.position);
        }
        else
        {
            Debug.LogError("Player or player start position not found!");
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the player GameObject if it's not already set
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (player != null && playerStartPosition != null)
        {
            TeleportPlayer(player, playerStartPosition.position);
        }
        else
        {
            Debug.LogError("Player or player start position not found!");
        }
    }

    private void TeleportPlayer(GameObject playerObject, Vector3 destination)
    {
        playerObject.transform.position = destination;
    }
}