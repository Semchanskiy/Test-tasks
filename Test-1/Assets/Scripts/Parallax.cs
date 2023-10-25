using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPosition;
    [SerializeField] private Camera Cam;
    public float parallaxEffect;
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (Cam.transform.position.x * (1 - parallaxEffect));

        float dist = (Cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPosition + dist,transform.position.y,transform.position.z);

        if (temp > startPosition + length)
        {
            startPosition += length;
        }
        else if (temp < startPosition - length)
        {
            startPosition-=length;
        }
    }
}
