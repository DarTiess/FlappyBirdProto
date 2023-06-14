using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Touch
{
    public class TouchPad : MonoBehaviour, IPointerClickHandler
    {
        public event Action ClickedTouch;
        public void OnPointerClick(PointerEventData eventData)
        {
            ClickedTouch?.Invoke();
        }
    }
}