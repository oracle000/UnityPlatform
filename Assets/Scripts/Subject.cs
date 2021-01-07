using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    event Action<int> Damange;

    public void TakeDamanage(int amount)
    {
        Damange.Invoke(amount); 
    }

}
