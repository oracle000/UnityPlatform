using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.MainScript.Movement
{
    public class PlayerMoveClimbUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            GameManager.instance.UpdateClimbUpKeyPressed(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            GameManager.instance.UpdateClimbUpKeyPressed(false);
        }
    }
}
