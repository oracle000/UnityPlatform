using UnityEngine;

public class ObsHUDCherryUpdate : MonoBehaviour
{
    SubPlayer _player;

    private void Awake()
    {
        _player = GetComponent<SubPlayer>();
    }
}
