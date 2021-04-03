
using System.Collections;
using System.Diagnostics;
using Assets.Scripts.Data;
using UnityEngine;
using TMPro;
using Assets.Scripts.Properties;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask cliff;

    private Rigidbody2D _rb;
    private Animator _anim;
    private Collider2D _coll;
    private float damage = 15f;
    private float jumpForce = 16f;
    private bool hitEnemy = false;
    private bool isFalling = false;
    private float speed = 8f;

    private bool collideWithLadder = false;
    
    private PlayerState state = PlayerState.idle;

    SubPlayer _player;  
    void Awake()
    {
        _player = GetComponent<SubPlayer>();
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _coll = GetComponent<Collider2D>();
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

        if (GameManager.instance.GetJumpKeyPressed())
        {
            if (_coll.IsTouchingLayers(ground) || _coll.IsTouchingLayers(cliff))
            {
                _player.IsJumping();
                _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
                state = PlayerState.jumping;
                GameManager.instance.UpdateJumpKeyPressed(false);
            }
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
                transform.position = new Vector3(-8, -1, 15);
                isFalling = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        DetectCollider(collision.gameObject);
        if (collision.gameObject.tag == "Ladder")
            collideWithLadder = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Ladder")
        {
            collideWithLadder = false;
            _rb.gravityScale = 5f;
            _rb.velocity = new Vector2(3, _rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DetectCollider(other.gameObject);        
    }    

    private void DetectCollider(GameObject collider)
    {
        if (collider.gameObject.CompareTag("Enemy-Spike"))
        {
            GameManager.instance.UpdateLeftKeyPressed(false);
            GameManager.instance.UpdateRightKeyPressed(false);

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
        else if (collider.gameObject.CompareTag("EnemyContainer"))
        {
            if (state != PlayerState.falling)
            {
                _player.TakeDamage();
                state = PlayerState.hurt;
                _rb.velocity = new Vector2(-damage, _rb.velocity.y);
            } 
        } else if (collider.gameObject.CompareTag("Enemy"))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 8f);

            GameManager.instance.UpdateLeftKeyPressed(false);
            GameManager.instance.UpdateRightKeyPressed(false);

            var enemyCollide = collider.gameObject.GetComponent<IEnemyDestory>();
            enemyCollide.Destory();


        } else if (collider.gameObject.CompareTag("End"))
        {
            GameManager.instance.MainMenu();
        }
        else if (collider.gameObject.CompareTag("Collectable"))
        {
            var item = collider.gameObject.GetComponent<ICollectible>();
            _player.IsItemPickUp();
            item.Collect();

        } else if (collider.gameObject.CompareTag("MovetoStage2"))
        {
            GameManager.instance.DisplayLevel2();
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

        if (Input.GetButtonDown("Jump") &&
            _coll.IsTouchingLayers(ground) &&
            state != PlayerState.falling &&
            state != PlayerState.jumping)
        {
            _player.IsJumping();
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            state = PlayerState.jumping;
        }
               
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
            if (_coll.IsTouchingLayers(ground) || _coll.IsTouchingLayers(cliff))
            {
                state = PlayerState.idle;
            }
        }else if (state == PlayerState.hurt)  
        {            
            if (Mathf.Abs(_rb.velocity.x) < 1f)
            {                
                state = PlayerState.idle; 
            }
        } else if (Mathf.Abs(_rb.velocity.x) > 1f)  
        {
            state = PlayerState.running;
        } else if ((Mathf.Abs(_rb.velocity.x) == 0f && _coll.IsTouchingLayers(ground)) || (_coll.IsTouchingLayers(cliff) && collideWithLadder == false))
        {
            state = PlayerState.idle;
        }        
    }
}
