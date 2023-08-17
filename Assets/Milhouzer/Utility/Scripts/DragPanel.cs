using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Milhouzer.Utility
{
    public class DragPanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
    {
        [SerializeField]
        private RectTransform dragRectTransform;
        [SerializeField]
        private Canvas canvas;

        public void OnPointerDown(PointerEventData eventData)
        {
            dragRectTransform.SetAsLastSibling();
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
        }
    }
}
