using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveClimbDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.instance.UpdateClimbDownKeyPressed(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.instance.UpdateClimbDownKeyPressed(false);
    }
}
