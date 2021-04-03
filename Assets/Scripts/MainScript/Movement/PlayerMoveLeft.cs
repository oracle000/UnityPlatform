using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.instance.UpdateLeftKeyPressed(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.instance.UpdateLeftKeyPressed(false);
    }
}
