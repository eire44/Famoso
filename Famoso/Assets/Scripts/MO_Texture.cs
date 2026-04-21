using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MO_Texture : MonoBehaviour
{
    public Sprite textureBeforeFlash;
    public Sprite textureAfterFlash = null;
    [HideInInspector] public Sprite currentTexture;
    [HideInInspector] public Texture beforeFlashTexture = null;
    public Texture afterFlashTexture = null;

    private void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        beforeFlashTexture = rend.material.mainTexture;
        currentTexture = textureBeforeFlash;
    }
}
