using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
//Used in InventorySlot and Game Manager
[RequireComponent(typeof(Rotate))]
public class DragNDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private bool inPlace;
    private Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Update Game Manager
        if (inPlace) inPlace = false;
        GameManager.instance.AllInPlace();
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Drag
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void SetInPlace(bool value) { this.inPlace = value; }
    public bool GetInPlace() { return this.inPlace; }
    public Vector3 GetStartPos() { return this.startPos; }

    public void ResetPiece()
    {
        //Reset piece position
        transform.position = startPos;
        inPlace = false;
    }

}
