using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageFinishScore : MonoBehaviour
{
    [Header("Score Panel")]
    [SerializeField] private StageTimer timer;
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private string nextLevelName;

    private CanvasGroup scoreCG;

    private changeScene sceneChange;

    private float finalTime = 0f;

    private void Start()
    {
        sceneChange = GetComponent<changeScene>();
        scoreCG = scorePanel.GetComponent<CanvasGroup>();
        scoreCG.LeanAlpha(0, 0.01f);
        scorePanel.SetActive(false);
    
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
        scoreCG.LeanAlpha(1, 0.2f);
        scoreText.text = "YOU FINISHED THE LEVEL!\nTIME: " + finalTime.ToString("F2");
    }

    public void GoToNextLevel()
    {
        // Unlock a new level
        sceneChange.UnlockNewLevel();

        // Go to the next level
        sceneController.instance.NextLevel(nextLevelName);
    }
}
