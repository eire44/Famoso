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
        GameObject dropped = eventData.pointerDrag;

        if (gameObject.CompareTag("Slot"))
        {
            if(transform.childCount == 0)
            {
                dropped.GetComponent<DragTexture>().dropped = true;
                RectTransform pieceRect = dropped.GetComponent<RectTransform>();
                RectTransform zoneRect = GetComponent<RectTransform>();

                pieceRect.SetParent(zoneRect);

                pieceRect.anchoredPosition = Vector2.zero;

                pieceRect.sizeDelta = zoneRect.sizeDelta;

                pieceRect.localScale = Vector3.one;

            }
        } 
        else if (gameObject.CompareTag("Trash"))
        {
            FindObjectOfType<MO_TexturesController>().deleteTexture(dropped);
        }
    }
}
