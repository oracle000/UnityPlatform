using UnityEngine;

public class Cherry : MonoBehaviour, ICollectible
{
    private Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void Collect()
    {
        _anim.SetTrigger("CHERRY_PICKUP");
        Destroy(gameObject, .3f);
    }
}
