using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;    
    private void Start()
    {        
        length = GetComponent<SpriteRenderer>().bounds.size.x;        
        startpos = transform.position.x;
    }

    private void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);        
    }
}
