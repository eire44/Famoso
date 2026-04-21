using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MO_TextureController : MonoBehaviour
{
    public Transform inventory;
    List<Transform> slots = new List<Transform>();
    int slotIndex = 0;
    public GameObject inventoryScreen;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform slot in inventory)
        {
            slots.Add(slot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventoryScreen.SetActive(!inventoryScreen.activeInHierarchy);
        }
    }

    public void saveTexture(GameObject memorableObject)
    {
        MO_Texture texture = memorableObject.GetComponent<MO_Texture>();

        if (texture != null)
        {
            if(findAvailableSlot() != null)
            {
                GameObject obj = new GameObject("ItemImage");
                Image img = obj.AddComponent<Image>();
                obj.AddComponent<DragTexture>();
                obj.transform.SetParent(findAvailableSlot());

                RectTransform objRect = obj.GetComponent<RectTransform>();

                objRect.anchoredPosition = Vector2.zero;

                objRect.sizeDelta = slots[slotIndex].GetComponent<RectTransform>().sizeDelta;

                objRect.localScale = Vector3.one;

                img.sprite = texture.texture;
            }
            else
            {
                Debug.Log("No hay slots disponibles");
            }
        }
        slotIndex++;
    }

    Transform findAvailableSlot()
    {
        foreach (Transform slot in slots)
        {
            if (slot.childCount == 0)
            {
                return slot;
            }
        }

        return null;
    }

    public void deleteTexture(GameObject textureToDelete)
    {
        Destroy(textureToDelete);
        slotIndex--;
    }
}
