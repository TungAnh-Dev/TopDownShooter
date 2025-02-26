using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HyperGame.Script
{
    public class FloatingJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public RectTransform joystickBg;
        public Image         joystickImage;
        public RectTransform joystickRect;

        private void Start()
        {
            this.joystickImage.color = new Color32(0, 0, 0, 0);
            this.joystickBg.gameObject.SetActive(false);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            this.joystickBg.anchoredPosition = this.joystickRect.anchoredPosition;
            this.joystickBg.gameObject.SetActive(true);
            this.joystickImage.color = new Color32(255, 255, 255, 255);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            this.joystickImage.color = new Color32(0, 0, 0, 0);
            this.joystickBg.gameObject.SetActive(false);
        }
    }
}