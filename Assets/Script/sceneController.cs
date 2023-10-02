using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class sceneController : MonoBehaviour
{
    public static sceneController instance;
    [SerializeField] Animator transitionAnim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
    }    
}
