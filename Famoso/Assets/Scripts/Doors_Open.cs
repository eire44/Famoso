using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Doors_Open : MonoBehaviour
{
    public Sprite characterToSave;
    AudioSource audiosource;
    [SerializeField] BlinkController blinkController;
    public string doorIndicationText = "";
    
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void callTriggerBlink()
    {
        blinkController.TriggerBlink(audiosource);
    }
    
}
