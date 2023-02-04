using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    RectTransform rectTransform;
    Transform parent;
    GameObject canvas;
    CanvasGroup canvasGoup;
    int siblingIndex;
    float scaleFactor;
    
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas");
        scaleFactor = canvas.GetComponent<Canvas>().scaleFactor;
        canvasGoup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parent = transform.parent;
        siblingIndex = transform.GetSiblingIndex();
        transform.SetParent(canvas.transform);
        canvasGoup.alpha = 0.75f;
        canvasGoup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parent);
        transform.SetSiblingIndex(siblingIndex);
        canvasGoup.alpha = 1.0f;
        canvasGoup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
