using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure
{
    public class TouchPad : MonoBehaviour, IPointerClickHandler, ITouchPad
    {
        public event Action ClickedTouch;
        public void OnPointerClick(PointerEventData eventData)
        {
            ClickedTouch?.Invoke();
        }
    }
}