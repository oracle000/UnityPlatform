using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SubPlayer : MonoBehaviour
{
    public event Action Damage = delegate { };
    public event Action Jump = delegate { };
    public event Action ItemPickUp = delegate { };
    public event Action OutOfBounds = delegate { };

    private int _health = 3;
    private int _scoreCount = 0;

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
    }

    public void TakeDamage()
    {
        _health -= 1;
        Damage.Invoke();
    }

    public void IsOutOfBounds()
    {
        OutOfBounds.Invoke();
    }

   
    
}
