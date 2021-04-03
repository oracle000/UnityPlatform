using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveJump : MonoBehaviour, IPointerDownHandler{    

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.instance.UpdateJumpKeyPressed(true);
    }    
}
