using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doors_Controller : MonoBehaviour
{
    Sprite characterToSave;
    public LayerMask targetLayer; //seleccionar doors
    MO_TexturesController textureController;
    // Start is called before the first frame update
    void Start()
    {
        textureController = FindObjectOfType<MO_TexturesController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayer))
            {
                Doors_Open door = hit.collider.gameObject.GetComponent<Doors_Open>();
                if(door != null)
                {
                    characterToSave = door.characterToSave;
                }
                
                if (checkIfCharacterSaved())
                {
                    door.TriggerBlink();
                    //que atraviese la puerta
                }
                else
                {
                    Debug.Log("falta algo por recordar");
                    //mensaje de que falta algo por recordar
                }
            }
        }
    }

    bool checkIfCharacterSaved()
    {
        if(iterateSlotsList(textureController.handySlots))
        {
            return true;
        }
        else
        {
            if (iterateSlotsList(textureController.slots))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    bool iterateSlotsList(List<Transform> slotsList)
    {
        foreach (Transform handySlot in slotsList)
        {
            if (handySlot.childCount == 1)
            {
                Image img = handySlot.GetChild(0).GetComponent<Image>();
                if (img != null)
                {
                    if (img.sprite == characterToSave)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
