using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float spriteLength, startPos;
    public float parallaxFactor, pixelsPerUnit;
    public GameObject cam;

    void Start()
    {
        startPos = transform.position.x;
        spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = cam.transform.position.x * (1 - parallaxFactor);
        float distance = cam.transform.position.x * parallaxFactor;

        Vector3 newPosition = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        transform.position = newPosition;

        if (temp > startPos + (spriteLength / 2)) startPos += spriteLength;
        else if (temp < startPos - (spriteLength / 2)) startPos -= spriteLength;
    }

    private Vector3 PixelPerfectClamp(Vector3 locationVector, float pixelsPerUnit)
    {
        Vector3 vectorInPixels = new Vector3(Mathf.CeilToInt(locationVector.x * pixelsPerUnit), Mathf.CeilToInt(locationVector.y * pixelsPerUnit), Mathf.CeilToInt(locationVector.z * pixelsPerUnit));
        return vectorInPixels / pixelsPerUnit;
    }
}
