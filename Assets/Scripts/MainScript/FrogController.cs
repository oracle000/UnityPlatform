using System.Collections;
using UnityEngine;

public class FrogController : MonoBehaviour
{

    private Rigidbody2D _rb;    
    private Collider2D _coll;    
    private bool _moveLeft = true;
    private bool _disJump = false;
    private bool checkFirst = true;

    [SerializeField] private LayerMask ground;

    private float speed = 0.6f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<Collider2D>();

        StartCoroutine(WaitFor(Random.Range(0, 5)));
    }    

    // Update is called once per frame
    void Update()
    {
           
    }


    IEnumerator WaitFor(float value)
    {
        while(true)
        {
            yield return new WaitForSeconds(value);
            if (_coll.IsTouchingLayers(ground))
            {
                if (_moveLeft)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    _rb.velocity = new Vector2(-4, 5);
                    _moveLeft = false;
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    _rb.velocity = new Vector2(4, 5);
                    _moveLeft = true;
                }
            }
        }
                         
    }
}
