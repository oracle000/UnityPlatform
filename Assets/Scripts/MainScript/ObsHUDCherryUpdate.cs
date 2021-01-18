using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObsHUDCherryUpdate : MonoBehaviour
{
    [SerializeField] SubPlayer _player;
    [SerializeField] private TextMeshProUGUI _cherryText;
    [SerializeField] private List<GameObject> life;

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
