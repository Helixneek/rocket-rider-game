using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageFinishScore : MonoBehaviour
{
    [SerializeField] private StageTimer timer;
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    private changeScene sceneChange;

    private float finalTime = 0f;

    private void Start()
    {
        sceneChange = GetComponent<changeScene>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Stop the timer and get the final time
            timer.currentlyRunning = false;
            finalTime = timer.currentTime;

            // Show the final score
            ShowFinalScore();
        }
    }

    private void ShowFinalScore()
    {
        scorePanel.SetActive(true);
        scoreText.text = "You finished the level!\nTime: " + finalTime.ToString("F2");
    }

    public void GoToNextLevel()
    {
        // Unlock a new level
        sceneChange.UnlockNewLevel();

        // Go to the next level
        sceneController.instance.NextLevel();
    }
}
