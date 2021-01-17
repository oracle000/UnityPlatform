using UnityEngine;

public class Cherry : MonoBehaviour, ICollectible
{
    private Animator _anim;
    [SerializeField] SubPlayer _player;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        StartObserving();
    }

    void StartObserving()
    {
        _player.ItemPickUp += PlayerPickupCollectibles;
    }

    void StopObserving()
    {
        _player.ItemPickUp -= PlayerPickupCollectibles;
    }


    void PlayerPickupCollectibles()
    {
    }

    public void Collect()
    {
        _anim.SetTrigger("CHERRY_PICKUP");
        Destroy(gameObject, .3f);
    }
}
