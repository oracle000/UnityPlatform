using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField]
    private Transform player;

    void Update()
    {        
        transform.position = new Vector3(
            player.position.x < -8f ? -8f : player.position.x,
            0, -8);
    }
}
