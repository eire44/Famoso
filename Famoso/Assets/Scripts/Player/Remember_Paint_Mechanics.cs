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

    private void Start()
    {
        Sprite_To_Texture_Dic = FindObjectOfType<Sprite_To_Texture_Dic>();
        SelectSlot(0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayer))
            {
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Memorable Objects"))
                {
                    MO_TextureController.saveTexture(hit.collider.gameObject);
                } 
                else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Paintable Objects"))
                {
                    Renderer rend = hit.collider.transform.GetComponent<Renderer>();
                    rend.material.mainTexture = currentSelectedTexture; //que ahora el paintable sea memorable tambien?
                }
                
            }
        }

        for (int i = 0; i < 6; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SelectSlot(i); //que solo guarde el numero y obtenga la texture cuando apriete para pintar?
            }
        }
    }

    void SelectSlot(int i)
    {
        currentSelectedSlot = MO_TextureController.handySlots[i];
        if (currentSelectedSlot.childCount == 1)
        {
            Image img = currentSelectedSlot.GetChild(0).GetComponent<Image>();
            if(img != null)
            {
                currentSelectedTexture = Sprite_To_Texture_Dic.convertSpriteToTexture[img.sprite];
            }
        }
    }
}
