using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doors_Open : MonoBehaviour
{
    public Sprite characterToSave;

    public Image blinkImage;
    public float blinkDuration = 1f;

    //bool open = false;
    //float DoorOpenAngle = -90.0f;
    //public Transform door;
    //public float smooth = 1.0f;
    private void Update()
    {
        //if (open)
        //{
        //    var target = Quaternion.Euler(0, DoorOpenAngle, 0);
        //    door.localRotation = Quaternion.Slerp(door.transform.localRotation, target, Time.deltaTime * 5 * smooth);

        //}
    }

    public void TriggerBlink()
    {
        //open = true;
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
            blinkImage.color = new Color(0f, 0f, 0f, alpha);

            yield return null;
        }


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
    }

    void changePlayerPosition()
    {
        //cambiar porsicion player
        //desvanecer puerta?
    }
}
