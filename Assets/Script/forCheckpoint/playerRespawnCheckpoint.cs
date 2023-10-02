using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRespawnCheckpoint : MonoBehaviour
{
    Vector2 startPos;
    private void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("killerPillar"))
        {
            Die();
        }
    }
    void Die()
    {
        StartCoroutine(Respawn(1f));
    }

    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
    }


}
