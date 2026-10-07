using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Doors_Open : MonoBehaviour
{
    public Sprite characterToSave;
    AudioSource audiosource;
    public BlinkController blinkController;
    public string doorIndicationText = "";
    //bool open = false;
    //float DoorOpenAngle = -90.0f;
    //public Transform door;
    //public float smooth = 1.0f;
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //if (open)
        //{
        //    var target = Quaternion.Euler(0, DoorOpenAngle, 0);
        //    door.localRotation = Quaternion.Slerp(door.transform.localRotation, target, Time.deltaTime * 5 * smooth);

        //}
    }

    public void callTriggerBlink()
    {
        blinkController.TriggerBlink(audiosource);
    }
    
}
