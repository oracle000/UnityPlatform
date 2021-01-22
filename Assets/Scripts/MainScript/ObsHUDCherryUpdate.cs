using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ObsHUDCherryUpdate : MonoBehaviour
{
    [SerializeField] SubPlayer _player;
    [SerializeField] private TextMeshProUGUI _cherryText;
    [SerializeField] private List<GameObject> life;
    

    void Start()
    {
        var playerLife = _player.GetComponent<SubPlayer>().GetHealth.ToString();

    }

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
        _cherryText.text = _player.GetComponent<SubPlayer>().GetScore.ToString();
    }

    void PlayerDamage()
    {
        Destroy(life[life.Count - 1].gameObject);
        life.RemoveAt(life.Count - 1);
    }
}
