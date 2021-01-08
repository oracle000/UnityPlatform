using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action Damage = delegate { };
    public event Action Jump = delegate { };
    public event Action ItemPickUp = delegate { };

    public void IsJumping()
    {
        Jump.Invoke();
    }

    public void IsItemPickUp()
    {
        Debug.Log("adadad");
        ItemPickUp.Invoke();
    }

    public void TakeDamage()
    {
        Damage.Invoke();
    }
}
