using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FrogController : MonoBehaviour
{

    private Rigidbody2D _rb;    
    private Collider2D _coll;    
    private bool _moveLeft = true;

    [SerializeField] private LayerMask ground;

    private float speed = 0.6f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<Collider2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (_coll.IsTouchingLayers(ground))
        {
            if (_moveLeft) 
            {
                transform.localScale = new Vector3(1, 1, 1);
                _rb.velocity = new Vector2(-4, 5);
                _moveLeft = false;
            } else
            {
                transform.localScale = new Vector3(-1, 1, 1);
                _rb.velocity = new Vector2(4, 5);
                _moveLeft = true;
            }
        }

        //if (_moveLeft)
        //{
        //    if (_coll.IsTouchingLayers(ground))
        //    {
                
        //    }                

        //} else
        //{
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}


     
        //rb.velocity = new Vector2(1, 0);
        // wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
        // transform.position = Vector2.MoveTowards(transform.position.x, wayPointPos.x, speed * Time.deltaTime);
    }
}
