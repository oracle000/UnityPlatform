using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.instance.UpdateRightKeyPressed(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.instance.UpdateRightKeyPressed(false);
    }
}
