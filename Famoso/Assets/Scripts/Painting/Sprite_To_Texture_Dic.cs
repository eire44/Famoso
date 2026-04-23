using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_To_Texture_Dic : MonoBehaviour
{
    [HideInInspector] public Dictionary<Sprite, Texture> convertSpriteToTexture = new Dictionary<Sprite, Texture>();
}
