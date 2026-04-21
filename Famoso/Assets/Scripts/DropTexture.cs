using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropTexture : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;

        if (gameObject.CompareTag("Slot"))
        {
            
        } else if (gameObject.CompareTag("Trash"))
        {
            FindObjectOfType<MO_TextureController>().deleteTexture(dropped);
        }
    }
}
