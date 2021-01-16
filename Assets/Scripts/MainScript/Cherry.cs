using System.Security;
using UnityEditor;
using UnityEngine;

public class Cherry : MonoBehaviour
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
        gameObject.SetActive(false);
    }


    void PlayerPickupCollectibles()
    {
        _anim.SetTrigger("CHERRY_PICKUP");
        StopObserving();
    }
}
