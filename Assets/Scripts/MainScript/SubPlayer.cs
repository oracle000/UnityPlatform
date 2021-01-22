using System;
using Assets.Scripts.Services;
using UnityEngine;

public class SubPlayer : MonoBehaviour
{
    public event Action Damage = delegate { };
    public event Action Jump = delegate { };
    public event Action ItemPickUp = delegate { };
    public event Action OutOfBounds = delegate { };

    private int _health;
    private int _scoreCount = 0;


    void Awake()
    {
        _health = GameManager.instance.GetPlayerLife();
        _scoreCount = GameManager.instance.GetPlayerScore();
    }

    public int GetHealth
    {
        get => _health;
        set
        {
            _health = value;
            _health = 3;
        }
    }

    public int GetScore
    {
        get => _scoreCount;
        set
        {
            _health = value;
            _scoreCount = 0;
        }
    }

    public void IsJumping()
    {
        Jump.Invoke();
    }

    public void IsItemPickUp()
    {
        _scoreCount += 1;
        ItemPickUp.Invoke();
        GameManager.instance.UpdatePlayerScore(1);
    }

    public void TakeDamage()
    {
        _health -= 1;
        Damage.Invoke();
        GameManager.instance.UpdatePlayerLife(1);
    }

    public void IsOutOfBounds()
    {
        _health -= 1;
        OutOfBounds.Invoke();
    }
}
