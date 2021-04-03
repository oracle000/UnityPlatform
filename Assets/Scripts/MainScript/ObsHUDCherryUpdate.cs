using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ObsHUDCherryUpdate : MonoBehaviour
{
    [SerializeField] SubPlayer _player;
    [SerializeField] private TextMeshProUGUI _cherryText;
    [SerializeField] private List<GameObject> life;
    [SerializeField] private GameObject GameOverPanel;
    
    void OnEnable()
    {
        _player.Damage += PlayerDamage;
    }

    void OnDisable()
    { 
        _player.Damage -= PlayerDamage;        
    }
    void Update()
    {
        _cherryText.text = GameManager.instance.GetPlayerScore().ToString();
        var playerLife = GameManager.instance.GetPlayerLife().ToString();
        if (playerLife != life.Count.ToString())
        {
            PlayerDamage();
        }
        
        if (Convert.ToInt32(playerLife) == 0)
        {
            GameManager.instance.SetEnableInput(false);
            GameOverPanel.gameObject.SetActive(true);            
        }        
    }

    public void ClickMenu()
    {
        GameOverPanel.gameObject.SetActive(true);
    }

    void PlayerDamage()
    {
        if (life.Count > 0)
        {
            Destroy(life[life.Count - 1].gameObject);
            life.RemoveAt(life.Count - 1);
        }        
    }
}
