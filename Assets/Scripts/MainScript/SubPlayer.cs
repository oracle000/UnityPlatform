using System;
using Assets.Scripts.Services;
using UnityEngine;

public class SubPlayer : MonoBehaviour
{
    public event Action Damage = delegate { };
    public event Action Jump = delegate { };
    public event Action ItemPickUp = delegate { };
    public event Action OutOfBounds = delegate { };

    public void IsJumping()
    {
        Jump.Invoke();
    }

    public void IsItemPickUp()
    {
        ItemPickUp.Invoke();
        GameManager.instance.UpdatePlayerScore(1);
    }

    public void TakeDamage()
    {
        Damage.Invoke();
        GameManager.instance.UpdatePlayerLife(1);
    }

    public void IsOutOfBounds()
    {
        OutOfBounds.Invoke();
        GameManager.instance.PitFall();
    }
}
