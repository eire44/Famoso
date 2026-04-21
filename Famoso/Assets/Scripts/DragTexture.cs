using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragTexture : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Image image;
    [HideInInspector] public Transform parentAfterDrag;
    RectTransform rectTransform;
    Vector2 originalSize;
    Vector3 originalScale;

    void Awake()
    {
        image = GetComponent<Image>();

        rectTransform = GetComponent<RectTransform>();

        originalSize = rectTransform.sizeDelta;
        originalScale = rectTransform.localScale;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        foreach (var graphic in GetComponentsInChildren<UnityEngine.UI.Graphic>())
        {
            graphic.raycastTarget = false;
        }

        rectTransform.sizeDelta = originalSize;
        rectTransform.localScale = originalScale;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

        foreach (var graphic in GetComponentsInChildren<UnityEngine.UI.Graphic>())
        {
            graphic.raycastTarget = true;
        }
    }
}
