using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D[] cursorFrames; // Array of cursor frames
    public float frameDuration = 0.1f; // Duration of each frame

    private int currentFrameIndex = 0;
    private float frameTimer = 0f;

    private void Start()
    {
        // Set the initial cursor texture
        Cursor.SetCursor(cursorFrames[currentFrameIndex], Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        // Update the frame timer
        frameTimer += Time.deltaTime;

        // Check if it's time to switch to the next frame
        if (frameTimer >= frameDuration)
        {
            // Increment the frame index (loop back to 0 if at the end)
            currentFrameIndex = (currentFrameIndex + 1) % cursorFrames.Length;

            // Update the cursor texture
            Cursor.SetCursor(cursorFrames[currentFrameIndex], Vector2.zero, CursorMode.Auto);

            // Reset the frame timer
            frameTimer = 0f;
        }
    }
}
