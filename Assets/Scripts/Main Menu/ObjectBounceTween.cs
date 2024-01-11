using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBounceTween : MonoBehaviour
{
    private Vector2 originalPosition;

    private void OnEnable()
    {
        originalPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        LeanTween.moveLocalY(gameObject, originalPosition.y + 10f, 0.5f).setLoopPingPong().setEase(LeanTweenType.easeInSine);
    }
}
