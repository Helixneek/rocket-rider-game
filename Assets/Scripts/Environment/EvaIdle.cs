using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaIdle : MonoBehaviour
{
    public Sprite[] idleFrames;
    public float frameDuration = 0.5f; // Duration of each frame
    private SpriteRenderer spriteRenderer;
    private int currentFrameIndex = 0;
    private float frameTimer = 0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idleFrames[currentFrameIndex];
    }

    private void Update()
    {
        // Update the frame timer
        frameTimer += Time.deltaTime;

        Idle();
    }

    private void Idle()
    {
        // Check if it's time to switch to the next frame
        if (frameTimer >= frameDuration)
        {
            // Increment the frame index (loop back to 0 if at the end)
            currentFrameIndex = (currentFrameIndex + 1) % idleFrames.Length;

            // Update the sprite
            spriteRenderer.sprite = idleFrames[currentFrameIndex];

            // Reset the frame timer
            frameTimer = 0f;
        }
    }
}
