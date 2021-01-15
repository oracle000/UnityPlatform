using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action Damaged = delegate { };
    public event Action Healed = delegate { };
    public event Action Killed = delegate { };    

    public void Heal()
    {
        Healed.Invoke();
    }

    public void TakeDamage()
    {
        Damaged.Invoke();
    }
}
