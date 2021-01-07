using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FrogController : MonoBehaviour
{

    private Rigidbody2D rb;    
    private Collider2D coll;    
    private bool moveLeft = false;

    [SerializeField] private LayerMask ground;

    private float speed = 0.6f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(coll.IsTouchingLayers(ground))
        {
            
        } else
        {

        }
        //rb.velocity = new Vector2(1, 0);
        // wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
        // transform.position = Vector2.MoveTowards(transform.position.x, wayPointPos.x, speed * Time.deltaTime);
    }
}
