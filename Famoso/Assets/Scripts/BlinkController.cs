using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkController : MonoBehaviour
{
    [SerializeField] Image blinkImage;
    [SerializeField] GameManager gameManager;
    [SerializeField] float blinkDuration = 1f;
    bool isBlinking = false;


    public void TriggerBlink(AudioSource doorAudio)
    {
        if (isBlinking) return;
        
        StartCoroutine(BlinkCoroutine(doorAudio));
    }

    IEnumerator BlinkCoroutine(AudioSource doorAudio)
    {
        isBlinking = true;

        doorAudio.Play();
        blinkImage.gameObject.SetActive(true);
        float timer = 0f;

        while (timer < blinkDuration)
        {
            timer += Time.deltaTime;

            float alpha = 0f + (timer / blinkDuration);
            blinkImage.color = new Color(0f, 0f, 0f, alpha);

            yield return null;
        }

        gameManager.changeRoom();

        timer = 0f;

        blinkImage.color = new Color(0f, 0f, 0f, 1f);

        while (timer < blinkDuration)
        {
            timer += Time.deltaTime;

            float alpha = 1f - (timer / blinkDuration);
            blinkImage.color = new Color(0f, 0f, 0f, alpha);

            yield return null;
        }

        blinkImage.color = new Color(0f, 0f, 0f, 0f);
        blinkImage.gameObject.SetActive(false);

        isBlinking = false;
    }
}
