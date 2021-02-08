
using System.Collections;
using UnityEngine;
using TMPro;
using Assets.Scripts.Properties;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Animator _anim;
    private Collider2D _coll;
    private IEnumerator coroutine;

    [SerializeField] private AudioClip ASHit;
    [SerializeField] private AudioClip ASJump;
    [SerializeField] private AudioClip ASCherry;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 25f;
    [SerializeField] private TextMeshProUGUI cherryText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private float damage = 10f;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject CherryObject;
    
    private GameObject wallSides;
    private bool hitEnemy = false;
    private bool isFalling = false;
    private bool isControlEnable = true;
    
    private PlayerState state = PlayerState.idle;

    SubPlayer _player;

    //private void OnEnable()
    //{
    //    _player.MoveLeft += PlayerMoveLeft;
    //    _player.MoveRight += PlayerMoveRight;
    //    _player.MoveJump += PlayerJumping;
    //}

    //private void OnDisable()
    //{
    //    _player.MoveLeft -= PlayerMoveLeft;
    //    _player.MoveRight -= PlayerMoveRight;
    //    _player.MoveJump -= PlayerJumping;
    //}

    void Awake()
    {
        _player = GetComponent<SubPlayer>();
    }


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _coll = GetComponent<Collider2D>();
        wallSides = GameObject.FindWithTag("WallSide");
    }
    void Update()
    {        

        if (GameManager.instance.GetLeftKeyPressed())
        {
            _rb.velocity = new Vector2(-speed, _rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        
        if (GameManager.instance.GetRightKeyPressed())
        {
            _rb.velocity = new Vector2(speed, _rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        if (state != PlayerState.hurt && GameManager.instance.GetEnableInput()) 
            Movement();

        SetAnimation(); 
        _anim.SetInteger("state", (int)state);  

        if (transform.position.y < -10)
        {
            if (isFalling == false)
            {
                isFalling = true;
                _player.IsOutOfBounds();
                transform.position = new Vector3(-12, 0, 0);
                isFalling = false;

            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetectCollider(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DetectCollider(other.gameObject);
    }

    private void DetectCollider(GameObject collider)
    {
        if (collider.gameObject.CompareTag("Enemy-Spike"))
        {
            _player.TakeDamage();
            state = PlayerState.hurt;

            if (collider.gameObject.transform.position.x > transform.position.x)
            {
                _rb.velocity = new Vector2(-damage, _rb.velocity.y);
            }                
            else
            {
                _rb.velocity = new Vector2(damage, _rb.velocity.y);
            }                
        }
        else if (collider.gameObject.CompareTag("Collectable"))
        {
            var item = collider.gameObject.GetComponent<ICollectible>();
            _player.IsItemPickUp();
            item.Collect();

        } else if (collider.gameObject.CompareTag("MovetoStage2"))
        {
            Debug.Log("move to state2");
        }
    }

    IEnumerator WaitReturn(float value, Collider2D _coll)
    {
        yield return new WaitForSeconds(value);
        Destroy(_coll.gameObject);
    }
    IEnumerator HitRemove()
    {
        yield return new WaitForSeconds(.5f);
        hitEnemy = false;
    }



    public void Movement()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal < 0 && !hitEnemy)
        {
            _rb.velocity = new Vector2(-speed, _rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);            
        }
        else if (moveHorizontal > 0 && !hitEnemy)
        {
            _rb.velocity = new Vector2(speed, _rb.velocity.y);
            transform.localScale = new Vector2(1, 1);            
        }

        if (Input.GetButtonDown("Jump") && _coll.IsTouchingLayers(ground))
        {
            _player.IsJumping();
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            state = PlayerState.jumping;
            
        }
    }

    void PlayerMoveLeft()
    {
        _rb.velocity = new Vector2(-speed, _rb.velocity.y);
        transform.localScale = new Vector2(-1, 1);        
        // _rb.AddForce(new Vector2(-speed, _rb.velocity.y));
        
    }

    void PlayerMoveRight()
    {
        _rb.velocity = new Vector2(speed, _rb.velocity.y);
        transform.localScale = new Vector2(1, 1);
    }
    void PlayerJumping()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        state = PlayerState.jumping;
    }

    private void SetAnimation()
    {
        if (state == PlayerState.jumping) 
        {            
            if (_rb.velocity.y < 1f) 
            {                
                state = PlayerState.falling;  
            }
        } else if (state == PlayerState.falling)
        {
            if (_coll.IsTouchingLayers(ground))
            {
                state = PlayerState.idle;
            }
        }else if (state == PlayerState.hurt)  
        {            
            if (Mathf.Abs(_rb.velocity.x) < 2f)
            {                
                state = PlayerState.idle; 
            }
        } else if (Mathf.Abs(_rb.velocity.x) > 2f)  
        {
            state = PlayerState.running;
        } else
        {
            state = PlayerState.idle;  
        }        
    }
}
