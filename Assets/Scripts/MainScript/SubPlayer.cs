using System;
using UnityEngine;

public class SubPlayer : MonoBehaviour
{
    public event Action Damage = delegate { };
    public event Action Jump = delegate { };
    public event Action ItemPickUp = delegate { };
    public event Action OutOfBounds = delegate { };

    int ScoreCount = 0;
    int Health = 3;

    public void IsJumping()
    {
        Jump.Invoke();
    }

    public void IsItemPickUp()
    {        
        ScoreCount += 1;
        ItemPickUp.Invoke();
    }

    public void TakeDamage()
    {
        Health -= 1;
        Damage.Invoke();
    }

    public void IsOutOfBounds()
    {
        OutOfBounds.Invoke();
    }
}
