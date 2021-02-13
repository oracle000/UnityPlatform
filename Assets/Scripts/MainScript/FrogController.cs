using System.Collections;
using UnityEngine;

public class FrogController : MonoBehaviour
{

    private Rigidbody2D _rb;    
    private Collider2D _coll;
    private Animator _anim;
    private bool _moveLeft = true;
    private Vector3 _frogLocation;

    private frogState state = frogState.idle;
    private enum frogState {idle, move, falling};


    [SerializeField] SubPlayer _subPlayer;
    [SerializeField] private LayerMask ground;


    private float speed = 0.6f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<Collider2D>();
        _anim = GetComponent<Animator>();

        StartCoroutine(WaitFor(Random.Range(2, 5)));

        _frogLocation = transform.position;
    }         

    void Update()
    {
        state = _coll.IsTouchingLayers(ground) ? state = frogState.idle : state = frogState.move;        
        _anim.SetInteger("state", (int)state);
    }    

    void OnCollisionEnter2D(Collision2D other)
    {        
        if (other.gameObject.CompareTag("Player"))
        {            
            transform.position = new Vector3(_frogLocation.x, _frogLocation.y, _frogLocation.z);
            _moveLeft = true;
        }
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
