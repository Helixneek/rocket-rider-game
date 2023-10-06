using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene1 : MonoBehaviour
{
    FadeInOut fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = FindAnyObjectByType<FadeInOut>();
    }


    public IEnumerator ChangeScene()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Make the player GameObject persist across scene changes.
            DontDestroyOnLoad(collision.gameObject);
            StartCoroutine(ChangeScene());
        }
    }
}


