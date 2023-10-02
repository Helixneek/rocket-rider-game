using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private Vector2 startPos;

    private void Start()
    {
        // Load the respawn position for the current scene from PlayerPrefs.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        string respawnKey = "RespawnPositionScene" + currentSceneIndex;
        if (PlayerPrefs.HasKey(respawnKey))
        {
            string respawnPosition = PlayerPrefs.GetString(respawnKey);
            startPos = JsonUtility.FromJson<Vector2>(respawnPosition);
        }
        else
        {
            startPos = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("killerPillar"))
        {
            Die();
        }
    }

    private void Die()
    {
        // Save the current respawn position for the current scene.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        string respawnKey = "RespawnPositionScene" + currentSceneIndex;
        string respawnPosition = JsonUtility.ToJson(startPos);
        PlayerPrefs.SetString(respawnKey, respawnPosition);
        PlayerPrefs.Save();

        // Teleport the player to the respawn position.
        transform.position = startPos;
    }

    private void Respawn()
    {
        // Teleport the player to the respawn position.
        transform.position = startPos;
    }
}