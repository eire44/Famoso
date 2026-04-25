using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Doors_Controller : MonoBehaviour
{
    Sprite characterToSave;
    MO_TexturesController textureController;
    Dialogs_Controller dialogsController;
    [HideInInspector] public GameObject paintableObjects;
    // Start is called before the first frame update
    void Start()
    {
        textureController = FindObjectOfType<MO_TexturesController>();
        dialogsController = FindObjectOfType<Dialogs_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Doors"))
                {
                    Doors_Open door = hit.collider.gameObject.GetComponent<Doors_Open>();
                    if (door != null)
                    {
                        characterToSave = door.characterToSave;
                    }

                    if (checkIfAllPainted())
                    {
                        door.TriggerBlink();
                    }
                    else
                    {
                        dialogsController.showIndication(door.doorIndicationText);
                        Debug.Log("falta algo por recordar");
                    }
                }
            }
        }
    }

    bool checkIfAllPainted()
    {
        int index = 0;
        foreach (Transform child in paintableObjects.transform)
        {
            if (child.gameObject.layer == LayerMask.NameToLayer("Paintable Objects"))
            {
                index++;
                Renderer rend = child.GetComponent<Renderer>();
                if (rend.material.mainTexture == null)
                {
                    return false;
                }
            }
        }

        return true;
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
