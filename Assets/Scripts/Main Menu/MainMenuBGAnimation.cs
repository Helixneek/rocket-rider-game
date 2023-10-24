using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBGAnimation : MonoBehaviour
{
    public Sprite[] idleFrames; // Array of idle animation frames
    public float frameDuration = 0.5f; // Duration of each frame
    private Image image;
    private int currentFrameIndex = 0;
    private float frameTimer = 0f;

    private void Start()
    {
        image = GetComponent<Image>();
        // Set the initial frame
        image.sprite = idleFrames[currentFrameIndex];
    }

    private void Update()
    {
        // Update the frame timer
        frameTimer += Time.deltaTime;

        // Check if it's time to switch to the next frame
        if (frameTimer >= frameDuration)
        {
            // Increment the frame index (loop back to 0 if at the end)
            currentFrameIndex = (currentFrameIndex + 1) % idleFrames.Length;

            // Update the sprite
            image.sprite = idleFrames[currentFrameIndex];

            // Reset the frame timer
            frameTimer = 0f;
        }
    }
}
