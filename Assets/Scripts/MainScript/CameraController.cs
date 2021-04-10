using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    
    [SerializeField]
    private Transform player;

    private string _levelName;


    void Start()
    {
        _levelName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (_levelName == "Main")
        {
            transform.position = new Vector3(player.position.x < -8f ? -8f : player.position.x, 0, -8);

            if (player.position.x > 145)            
                transform.position = new Vector3(145, transform.position.y, transform.position.z);
            

        } else if (_levelName == "Level2")
        {            
            if (player.position.x <= -38)            
                transform.position = new Vector3(-38, player.position.y, transform.position.z);            
            else            
                transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
            
            if (player.position.x > 107)
            {
                transform.position = new Vector3(107, player.position.y, transform.position.z);
            }
        }
    }
}
