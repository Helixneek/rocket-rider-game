using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    public static int selectedLevel;
    public int level;
    public Text levelText;

    void Start()
    {
        levelText.text = level.ToString();
    }
    public void changeScene()
    {
        selectedLevel = level;
        SceneManager.LoadScene("Level Selection ");
    }
}