using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeforScene2 : MonoBehaviour
{
    FadeInOut fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = FindAnyObjectByType<FadeInOut>();

        fade.Fadeout();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
