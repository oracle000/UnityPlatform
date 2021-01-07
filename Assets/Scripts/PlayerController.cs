
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Assets.Scripts.Properties;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
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

    private AudioSource audio;
    private GameObject wallSides;
    private int cherries = 0;                
    private bool hitEnemy = false;
    private bool isFalling = false;
    private bool isControlEnable = true;
    
    private State state = State.idle;    
    
    void Awake()
    {        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        audio = GetComponent<AudioSource>();                

        wallSides = GameObject.FindWithTag("WallSide");                
        
    }
    void Update()
    {        
        if (state != State.hurt && isControlEnable)
        {
            Movement();
        }
        SetAnimation();        
        anim.SetInteger("state", (int)state);

        if (Input.GetKeyDown(KeyCode.Space))
        {
     
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
     
        }

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


        lifeText.text = FindObjectOfType<GameManager>().PlayerLife().ToString();                        

        if (FindObjectOfType<GameManager>().PlayerLife() < 1)
        {
            gameOverPanel.SetActive(true);
            isControlEnable = false;
            FindObjectOfType<GameManager>().GameOver();            
        } else
        {
            gameOverPanel.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Collectable")
        {
            audio.PlayOneShot(ASCherry, .5f);
            GetComponent<AudioSource>().Play();                        
            
            CherryObject = collision.gameObject;                        
            cherries += 1;
            cherryText.text = cherries.ToString();

            coroutine = WaitReturn(.4f, collision);
            StartCoroutine(coroutine);            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Enemy-Spike") 
        {            
            state = State.hurt;
            if (other.gameObject.transform.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(-damage, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(damage, rb.velocity.y);
            }

            FindObjectOfType<GameManager>().UpdatePlayerLife(1);
            audio.PlayOneShot(ASHit, .5f);
            StartCoroutine(HitRemove());         
        }
    }    

    IEnumerator WaitReturn(float value, Collider2D coll)
    {
        yield return new WaitForSeconds(value);
        Destroy(coll.gameObject);
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
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);            
        }
        else if (moveHorizontal > 0 && !hitEnemy)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);            
        }

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            audio.PlayOneShot(ASJump, .5f);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jumping;
        }
    }

    private bool CollideToWall(Collision2D wall)
    {
        return coll.gameObject.tag == "WallSide";
    }


    private void SetAnimation()
    {
        if (state == State.jumping) 
        {            
            if (rb.velocity.y < 1f) 
            {                
                state = State.falling;  
            }
        } else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }else if (state == State.hurt)  
        {            
            if (Mathf.Abs(rb.velocity.x) < 2f)
            {                
                state = State.idle; 
            }
        } else if (Mathf.Abs(rb.velocity.x) > 2f)  
        {
            state = State.running;
        } else
        {
            state = State.idle;  
        }        
    }
}
