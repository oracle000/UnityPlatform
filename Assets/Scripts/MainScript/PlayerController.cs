
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private int cherries = 0;                
    private bool hitEnemy = false;
    private bool isFalling = false;
    private bool isControlEnable = true;
    
    private State state = State.idle;

    SubPlayer _player;
    
    void Awake()
    {        
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _coll = GetComponent<Collider2D>();
        _player = GetComponent<SubPlayer>();
        wallSides = GameObject.FindWithTag("WallSide");
        
        
    }
    void Update()
    {        
        if (state != State.hurt && isControlEnable) 
            Movement();
        

        SetAnimation(); 
        _anim.SetInteger("state", (int)state);  

        if (transform.position.y < -10)
        {
            if (isFalling == false)
            {
                FindObjectOfType<GameManager>().UpdatePlayerLife(1);
                isFalling = true;

                if (FindObjectOfType<GameManager>().PlayerLife() != 0)
                    ReloadScene();
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
            state = State.hurt;
            if (collider.gameObject.transform.position.x > transform.position.x)
            {
                _rb.velocity = new Vector2(-damage, _rb.velocity.y);
            }
            else
            {
                _rb.velocity = new Vector2(damage, _rb.velocity.y);
            }

            FindObjectOfType<GameManager>().UpdatePlayerLife(1);
            StartCoroutine(HitRemove());
        }
        else if (collider.gameObject.CompareTag("Collectable"))
        {
            var item = collider.gameObject.GetComponent<ICollectible>();
            _player.IsItemPickUp();
            item.Collect();
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


    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void Movement()
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
            state = State.jumping;
        }
    }


    private void SetAnimation()
    {
        if (state == State.jumping) 
        {            
            if (_rb.velocity.y < 1f) 
            {                
                state = State.falling;  
            }
        } else if (state == State.falling)
        {
            if (_coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }else if (state == State.hurt)  
        {            
            if (Mathf.Abs(_rb.velocity.x) < 2f)
            {                
                state = State.idle; 
            }
        } else if (Mathf.Abs(_rb.velocity.x) > 2f)  
        {
            state = State.running;
        } else
        {
            state = State.idle;  
        }        
    }
}
