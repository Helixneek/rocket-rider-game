using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonWithHover : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip hoverAudioClip;
    public AudioClip pressedAudioClip;

    private Image button;
    private RectTransform rectTransform;
    private Vector2 originalPosition;

    void Start()
    {
        // Get the Button component and store the original position
        button = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;

        // Get the AudioSource to play the audio files.
        audioSource = GetComponent<AudioSource>();

        // Add this script as a listener for pointer enter and exit events
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entryEnter = new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter };
        entryEnter.callback.AddListener((data) => { OnHover(); });
        trigger.triggers.Add(entryEnter);

        EventTrigger.Entry entryExit = new EventTrigger.Entry { eventID = EventTriggerType.PointerExit };
        entryExit.callback.AddListener((data) => { OnExit(); });
        trigger.triggers.Add(entryExit);
    }

    void OnHover()
    {
        audioSource.clip = hoverAudioClip;
        audioSource.Play();

        // Move the button slightly up using LeanTween
        LeanTween.moveLocalY(gameObject, originalPosition.y + 10f, 0.3f)
                 .setEase(LeanTweenType.easeOutQuad);
    }

    void OnExit()
    {
        // Move the button back to its original position
        LeanTween.moveLocalY(gameObject, originalPosition.y, 0.3f)
                 .setEase(LeanTweenType.easeOutQuad);
    }

    public void SFXOnClick()
    {
        audioSource.clip = pressedAudioClip;
        audioSource.Play();
    }
}
