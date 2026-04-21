using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doors_Open : MonoBehaviour
{
    public Sprite characterToSave;

    public Image blinkImage;
    public float blinkDuration = 1f;
    

    public void TriggerBlink()
    {
        StartCoroutine(BlinkCoroutine());
    }

    IEnumerator BlinkCoroutine()
    {
        //sonido de puerta que se abre
        blinkImage.gameObject.SetActive(true);
        float timer = 0f;

        while (timer < blinkDuration)
        {
            timer += Time.deltaTime;

            float alpha = 0f + (timer / blinkDuration);
            blinkImage.color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }


        timer = 0f;

        blinkImage.color = new Color(1f, 1f, 1f, 1f);

        while (timer < blinkDuration)
        {
            timer += Time.deltaTime;

            float alpha = 1f - (timer / blinkDuration);
            blinkImage.color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }

        blinkImage.color = new Color(1f, 1f, 1f, 0f);
        blinkImage.gameObject.SetActive(false);
    }

    void changePlayerPosition()
    {
        //cambiar porsicion player
        //desvanecer puerta?
    }
}
