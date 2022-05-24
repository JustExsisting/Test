using UnityEngine;
using UnityEngine.EventSystems;

public class TouchBase
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}