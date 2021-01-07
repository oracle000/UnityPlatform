using UnityEngine;

public class CherryController : MonoBehaviour
{

    private Animator anim;
    [SerializeField]
    public GameObject cherry;


    void Start()
    {
        anim = GetComponent<Animator>();
        cherry = GetComponent<GameObject>();
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("CHERRY_PICKUP");
             Destroy(cherry.gameObject);
        }
    }
}
