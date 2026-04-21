using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MO_TexturesController : MonoBehaviour
{
    public Transform inventory;
    public Transform handyInventory;
    [HideInInspector] public List<Transform> slots = new List<Transform>();
    [HideInInspector] public List<Transform> handySlots = new List<Transform>();
    public GameObject inventoryScreen;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform slot in inventory)
        {
            slots.Add(slot);
        }

        foreach (Transform slot in handyInventory)
        {
            handySlots.Add(slot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryScreen.SetActive(!inventoryScreen.activeInHierarchy);
        }
    }

    public void saveTexture(GameObject memorableObject)
    {
        MO_Texture texture = memorableObject.GetComponent<MO_Texture>();

        if (texture != null)
        {
            Transform handySlot = findAvailableSlot(handySlots);
            if (handySlot != null)
            {
                createInventoryItem(texture, handySlot);
            }
            else
            {
                Debug.Log("No hay slots disponibles a mano");

                Transform slot = findAvailableSlot(slots);
                if (slot != null)
                {
                    createInventoryItem(texture, slot);
                }
                else
                {
                    Debug.Log("No hay slots disponibles en el inventario");
                }
            }
        }
    }

    Transform findAvailableSlot(List<Transform> slotsList)
    {
        foreach (Transform slot in slotsList)
        {
            if (slot.childCount == 0)
            {
                return slot;
            }
        }

        return null;
    }

    void createInventoryItem(MO_Texture texture, Transform slot)
    {
        GameObject obj = new GameObject("ItemImage");
        Image img = obj.AddComponent<Image>();
        obj.AddComponent<DragTexture>();
        
        obj.transform.SetParent(slot);

        RectTransform objRect = obj.GetComponent<RectTransform>();

        objRect.anchoredPosition = Vector2.zero;

        objRect.sizeDelta = slot.GetComponent<RectTransform>().sizeDelta;

        objRect.localScale = Vector3.one;

        img.sprite = texture.currentSprite;
    }

    public void deleteTexture(GameObject textureToDelete)
    {
        Destroy(textureToDelete);
    }
}
