using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float currentTime = 0f;
    public bool currentlyRunning = true;

    private void Update()
    {
        if(currentlyRunning)
        {
            RunTimer();
        }
    }

    private void RunTimer()
    {
        currentTime += 1f * Time.deltaTime;
        timerText.text = currentTime.ToString("F2");
    }
}
