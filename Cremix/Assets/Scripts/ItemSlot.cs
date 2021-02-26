using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [Header("Piece rotation speed")]
    public float speed;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            //Adjust piece position
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            //Set piece rotation speed
            eventData.pointerDrag.GetComponent<Rotate>().SetSpeed(this.speed);
            //Set piece in place to true
            eventData.pointerDrag.GetComponent<DragNDrop>().SetInPlace(true);
            //Check if all pieces are in place
            GameManager.instance.AllInPlace();
        }
    }
}
