using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class DragListenr : MonoBehaviour,IDragHandler
{
    public System.Action<PointerEventData> DragEvent;

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (DragEvent != null)
            DragEvent(eventData);
    }

}
