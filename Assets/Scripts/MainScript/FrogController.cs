using System.Collections;
using UnityEngine;

public class FrogController : MonoBehaviour, IEnemyDestory
{

    private Rigidbody2D _rb;    
    private Collider2D _coll;
    private Animator _anim;
    private bool _moveLeft = true;
    private bool _isHit = false;
    private Vector3 _frogLocation;

    private frogState state = frogState.idle;
    private enum frogState {idle, move, falling, destroy};


    [SerializeField] SubPlayer _subPlayer;
    [SerializeField] private LayerMask ground;


    private float speed = 0.6f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<Collider2D>();
        _anim = GetComponent<Animator>();

        StartCoroutine(WaitFor(Random.Range(3, 5)));

        _frogLocation = transform.position;
        
    }         

    void Update()
    {                
        if (_coll.IsTouchingLayers(ground) && _isHit == false)
        {
            state = frogState.idle;
        } else if (_isHit)
        {
            state = frogState.destroy;
            Destroy(gameObject, .2f);
        } else
        {
            state = frogState.move;
        }        
        _anim.SetInteger("state", (int)state);        
    }    

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
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
                    state = frogState.move;

                    transform.localScale = new Vector3(1, 1, 1);
                    _rb.velocity = new Vector2(-4, 5);
                    _moveLeft = false;
                }
                else 
                {
                    state = frogState.move;
                    transform.Translate(Vector2.right * (Time.deltaTime * 5));

                    transform.localScale = new Vector3(-1, 1, 1);
                    _rb.velocity = new Vector2(4, 5);
                    _moveLeft = true;
                } 
            }            
        }                         
    }

    public void Destory()
    {
        _isHit = true;
        Debug.Log("here");        
    }
}
