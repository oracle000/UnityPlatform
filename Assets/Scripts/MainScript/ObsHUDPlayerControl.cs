using UnityEngine;

public class ObsHUDPlayerControl : MonoBehaviour
{
    [SerializeField] SubPlayer _player;
   
    public void Jump()
    {     
        _player.IsJumping();
    }

    public void MoveLeft()
    {
        Debug.Log(Input.GetMouseButton(0));

        //if(Input.GetMouseButtonDown(0))
        //{
        //    _player.IsMoveLeft();
        //} else
        //{
        //    _player.IsMoveLeftStop();
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    Debug.Log("up");
        //}
    }

    public void MoveRight()
    {     
        _player.IsMoveRight();
    }

}
