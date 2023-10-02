using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float currentTime = 0f;

    private void Update()
    {
        currentTime += 1f * Time.deltaTime;
        timerText.text = currentTime.ToString("F2");
    }
}
