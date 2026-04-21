using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashEffect : MonoBehaviour
{
    public Image flashImage;
    public float flashDuration = 1f;
    bool changeTexture = true;
    float emitFlash = 20f;
    float time = 0f;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > emitFlash)
        {
            time = 0;
            emitFlash = Random.Range(15f, 20f);
            TriggerFlash();
        }
    }

    public void TriggerFlash()
    {
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        changeTexture = !changeTexture;
        flashImage.gameObject.SetActive(true);
        float timer = 0f;

        while (timer < flashDuration)
        {
            timer += Time.deltaTime;

            float alpha = 0f + (timer / flashDuration);
            flashImage.color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }

        changeTextures();


        timer = 0f;

        flashImage.color = new Color(1f, 1f, 1f, 1f);

        while (timer < flashDuration)
        {
            timer += Time.deltaTime;

            float alpha = 1f - (timer / flashDuration);
            flashImage.color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }

        flashImage.color = new Color(1f, 1f, 1f, 0f);
        flashImage.gameObject.SetActive(false);
    }

    void changeTextures()
    {
        int layer = LayerMask.NameToLayer("Memorable Objects");

        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (obj.layer == layer)
            {
                MO_Texture texture = obj.GetComponent<MO_Texture>();

                if (texture != null)
                {
                    if(texture.afterFlashTexture != null)
                    {
                        Renderer rend = texture.GetComponent<Renderer>();
                        if (changeTexture)
                        {
                            rend.material.mainTexture = texture.beforeFlashTexture;
                            texture.currentSprite = texture.spriteBeforeFlash;
                        }
                        else
                        {
                            rend.material.mainTexture = texture.afterFlashTexture;
                            texture.currentSprite = texture.spriteAfterFlash;
                        }
                    }
                }
            }
        }
    }
}
