using System;
using Assets.Scripts.Services;
using UnityEngine;

public class SubPlayer : MonoBehaviour
{
    public event Action Damage = delegate { };
    public event Action Jump = delegate { };
    public event Action ItemPickUp = delegate { };
    public event Action OutOfBounds = delegate { };
    public event Action PlayerStop = delegate { };
    public event Action PlayerResume = delegate { };

    public void IsJumping()
    {
        Jump.Invoke();
    }

    public void IsItemPickUp()
    {
        ItemPickUp.Invoke();
        GameManager.instance.UpdatePlayerScore(1);
    }

    public void PlayerIsDead()
    {
        PlayerStop.Invoke();
        GameManager.instance.IsGamePauseOrStop();
    }

    public void PlayerIsNotDead()
    {
        PlayerResume.Invoke();
        GameManager.instance.IsGameResume();
    }
    public void TakeDamage()
    {
        Damage.Invoke();
        GameManager.instance.UpdatePlayerLife(1);
    }

    public void IsOutOfBounds()
    {
        OutOfBounds.Invoke();
        GameManager.instance.PitFall(1);
    }
}
