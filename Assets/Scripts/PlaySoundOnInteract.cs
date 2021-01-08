using UnityEngine;

public class PlaySoundOnInteract : MonoBehaviour
{
    [SerializeField] AudioClip _itemSound;
    [SerializeField] AudioClip _jumpSound;
    [SerializeField] AudioClip _hitSound;

    Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.Damage += OnDamange;
        _player.Jump += OnJump;
        _player.ItemPickUp += OnItemPickUp;
    }

    private void OnDisable()
    {
        _player.Damage -= OnDamange;
        _player.Jump -= OnJump;
        _player.ItemPickUp -= OnItemPickUp;
    }

    void OnDamange()
    {
        AudioSource.PlayClipAtPoint(_hitSound, transform.position);
        
    }

    void OnJump()
    {
        AudioSource.PlayClipAtPoint(_jumpSound, transform.position);
    }

    void OnItemPickUp()
    {
        AudioSource.PlayClipAtPoint(_itemSound, transform.position);
    }

}
