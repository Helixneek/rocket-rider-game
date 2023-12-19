using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFXManager : MonoBehaviour
{
    [SerializeField] private AudioClip hoverAudioClip;
    [SerializeField] private AudioClip pressedAudioClip;
    private ButtonWithHover[] buttonsWithHover;

    private void Start()
    {
        buttonsWithHover = FindObjectsOfType<ButtonWithHover>();

        // Set the buttons SFX
        SetSFX();
    }

    private void SetSFX()
    {
        foreach (var button in buttonsWithHover)
        {
            button.hoverAudioClip = hoverAudioClip;
            button.pressedAudioClip = pressedAudioClip;
        }
    }
}
