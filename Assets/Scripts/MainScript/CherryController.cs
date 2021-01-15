using UnityEngine;

public class CherryController : MonoBehaviour
{

    private Animator anim;
    [SerializeField]
    public GameObject cherry;
    [SerializeField] SubPlayer _player;

    void Start()
    {
        anim = GetComponent<Animator>();
        cherry = GetComponent<GameObject>();
        _player = GetComponent<SubPlayer>();       
    }    

    private void OnTriggerEnter2D(Collider2D collision) 
    {
    }

    private void OnEnable()
    {        
        _player.ItemPickUp += PlayerPickupCollectibles;
    }

    private void OnDisable()
    { 
        _player.ItemPickUp -= PlayerPickupCollectibles;
    }
    void PlayerPickupCollectibles()
    {        
        anim.SetTrigger("CHERRY_PICKUP");
    }
}
