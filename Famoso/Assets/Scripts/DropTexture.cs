using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DropTexture : MonoBehaviour, IDropHandler
{
    bool occupiedSlot = false;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;

        if (gameObject.CompareTag("Slot"))
        {
            if(transform.childCount == 0)
            {
                GameObject obj = new GameObject("ItemImage");
                Image img = obj.AddComponent<Image>();
                obj.transform.SetParent(transform);

                RectTransform objRect = obj.GetComponent<RectTransform>();

                objRect.anchoredPosition = Vector2.zero;

                objRect.sizeDelta = transform.GetComponent<RectTransform>().sizeDelta;

                objRect.localScale = Vector3.one;

                //MO_Texture texture = memorableObject.GetComponent<MO_Texture>();
                //img.sprite = texture.texture;
            }
        } 
        else if (gameObject.CompareTag("Trash"))
        {
            FindObjectOfType<MO_TexturesController>().deleteTexture(dropped);
        }
    }
}
