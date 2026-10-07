using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DropTexture : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;

        if (droppedObject == null)
            return;

        DragTexture dragTexture = droppedObject.GetComponent<DragTexture>();

        if (dragTexture == null)
            return;

        if (gameObject.CompareTag("Slot"))
        {
            if (transform.childCount == 0)
            {
                dragTexture.dropped = true;

                RectTransform pieceRect = droppedObject.GetComponent<RectTransform>();
                RectTransform zoneRect = GetComponent<RectTransform>();

                pieceRect.SetParent(zoneRect);

                pieceRect.anchoredPosition = Vector2.zero;
                pieceRect.sizeDelta = zoneRect.sizeDelta;
                pieceRect.localScale = Vector3.one;
            }
        }
        else if (gameObject.CompareTag("Trash"))
        {
            FindObjectOfType<MO_TexturesController>().deleteTexture(droppedObject);
        }
    }
}

