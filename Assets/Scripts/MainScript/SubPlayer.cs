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
        var data = UpdateDatabaseService.LoadPlayerData();
        _health = Convert.ToInt32(data.PlayerHealth);
        _scoreCount = Convert.ToInt32(data.PlayerScore);
    }

    void Start()
    {
        //_health = Convert.ToInt32(UpdateDatabaseService.GetPlayerHealth());
        
        _health = 0;
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
        UpdateDatabaseService.SavePlayerData(_scoreCount, _health, 0);
        ItemPickUp.Invoke();
    }

    public void TakeDamage()
    {
        _health -= 1;
        UpdateDatabaseService.SavePlayerData(_scoreCount, _health, 0);
        Damage.Invoke();
    }

    public void IsOutOfBounds()
    {
        _health -= 1;
        OutOfBounds.Invoke();
    }
}
