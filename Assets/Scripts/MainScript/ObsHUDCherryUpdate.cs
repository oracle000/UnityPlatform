using TMPro;
using UnityEngine;

public class ObsHUDCherryUpdate : MonoBehaviour
{
    [SerializeField] SubPlayer _player;
    [SerializeField] private TextMeshProUGUI _cherryText;
    [SerializeField] private TextMeshProUGUI _lifeText;

    void Update()
    {
        _cherryText.text = _player.GetComponent<SubPlayer>().GetScore.ToString();
        _lifeText.text = _player.GetComponent<SubPlayer>().GetHealth.ToString();
    }
}
