using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class UClickListener : MonoBehaviour, IPointerClickHandler, IPointerUpHandler
{
    public System.Action<PointerEventData> PointUpEvent;
    public System.Action<PointerEventData> ClickEvent;
    public void OnPointerUp(PointerEventData eventData)
    {
        if (PointUpEvent != null)
            PointUpEvent(eventData);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (ClickEvent != null)
            ClickEvent(eventData);
    }

}
