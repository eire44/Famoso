using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MO_Texture : MonoBehaviour
{
    public Sprite spriteBeforeFlash;
    public Sprite spriteAfterFlash = null;
    [HideInInspector] public Sprite currentSprite;
    [HideInInspector] public Texture beforeFlashTexture = null;
    public Texture afterFlashTexture = null;

    private void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        beforeFlashTexture = rend.material.mainTexture;
        currentSprite = spriteBeforeFlash;

        if(spriteBeforeFlash != null && beforeFlashTexture != null)
        {
            FindObjectOfType<Sprite_To_Texture_Dic>().convertSpriteToTexture[spriteBeforeFlash] = beforeFlashTexture;
        }

        if (spriteAfterFlash != null && afterFlashTexture != null)
        {
            FindObjectOfType<Sprite_To_Texture_Dic>().convertSpriteToTexture[spriteAfterFlash] = afterFlashTexture;
        }
    }
}
