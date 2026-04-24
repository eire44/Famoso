using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Remember_Paint_Mechanics : MonoBehaviour
{
    public LayerMask targetLayer;
    public MO_TexturesController MO_TextureController;
    Transform currentSelectedSlot;
    Texture currentSelectedTexture;
    Sprite_To_Texture_Dic Sprite_To_Texture_Dic;
    [HideInInspector] public int currentSelectedSlot_Index = 0;

    private void Start()
    {
        Sprite_To_Texture_Dic = FindObjectOfType<Sprite_To_Texture_Dic>();
        //bordes de diferentes colores segun si es memorable o paintable
    }

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
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Memorable Objects"))
                {
                    MO_TextureController.saveTexture(hit.collider.gameObject);
                } 
                else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Paintable Objects"))
                {
                    Renderer rend = hit.collider.transform.GetComponent<Renderer>();
                    rend.material.mainTexture = currentSelectedTexture;
                }
                
            }
        }

        for (int i = 0; i < 6; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                int previousSelectedIndex = currentSelectedSlot_Index;

                //MO_TextureController.handySlots[currentSelectedSlot_Index].GetComponent<Outline>().enabled = false;
                currentSelectedSlot_Index = i;
                SelectSlot(currentSelectedSlot_Index);
                //if (SelectSlot(currentSelectedSlot_Index))
                //{
                //    outlineSelectedHandySlot(previousSelectedIndex, false);
                //}
            }
        }
    }

    bool SelectSlot(int i)
    {
        currentSelectedSlot = MO_TextureController.handySlots[i];


        if (currentSelectedSlot.childCount == 1)
        {
            Image img = currentSelectedSlot.GetChild(0).GetComponent<Image>();
            if(img != null)
            {
                currentSelectedTexture = Sprite_To_Texture_Dic.convertSpriteToTexture[img.sprite];

                currentSelectedSlot.GetComponent<Outline>().enabled = true;
                for (int j = 0; j < MO_TextureController.handySlots.Count; j++)
                {
                    if (j != i)
                    {
                        MO_TextureController.handySlots[j].GetComponent<Outline>().enabled = false;
                    }
                }
                //outlineSelectedHandySlot(currentSelectedSlot_Index, true);
                return true;
            }
        }

        return false;
    }

    public void outlineSelectedHandySlot(int slotIndex, bool enable)
    {
        MO_TextureController.handySlots[slotIndex].GetComponent<Outline>().enabled = enable;
    }
}
