using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options_Controller : MonoBehaviour
{
    //public AudioMixer audioMixer;
    //public Slider musicSlider;
    //public Slider sfxSlider;
    //public Slider turntableSlider;
    //void Start()
    //{
    //    float music = PlayerPrefs.GetFloat("Music_Volume", 1f);
    //    float sfx = PlayerPrefs.GetFloat("SFX_Volume", 1f);
    //    float turntable = PlayerPrefs.GetFloat("Turntable_Volume", 1f);

    //    music = Mathf.Clamp(music, 0.0001f, 1f);
    //    sfx = Mathf.Clamp(sfx, 0.0001f, 1f);
    //    turntable = Mathf.Clamp(sfx, 0.0001f, 1f);

    //    float musicCurved = music * music;
    //    float sfxCurved = sfx * sfx;
    //    float turntableCurved = turntable * turntable;

    //    audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicCurved) * 20);
    //    audioMixer.SetFloat("SFXVolume", Mathf.Log10(sfxCurved) * 20);
    //    audioMixer.SetFloat("TurntableVolume", Mathf.Log10(turntableCurved) * 20);

    //    musicSlider.value = music;
    //    sfxSlider.value = sfx;
    //    turntableSlider.value = turntable;
    //}

    //public void SetSFXVolume(float volume)
    //{
    //    float curved = volume * volume;

    //    float safeVolume = Mathf.Clamp(curved, 0.0001f, 1f);

    //    audioMixer.SetFloat("SFXVolume", Mathf.Log10(safeVolume) * 20);
    //    PlayerPrefs.SetFloat("SFX_Volume", volume);
    //}
    //public void SetMusicVolume(float volume)
    //{
    //    float curved = volume * volume;

    //    float safeVolume = Mathf.Clamp(curved, 0.0001f, 1f);
    //    audioMixer.SetFloat("MusicVolume", Mathf.Log10(safeVolume) * 20);
    //    PlayerPrefs.SetFloat("Music_Volume", volume);
    //}
    //public void SetTurntableVolume(float volume)
    //{
    //    float curved = volume * volume;

    //    float safeVolume = Mathf.Clamp(curved, 0.0001f, 1f);
    //    audioMixer.SetFloat("TurntableVolume", Mathf.Log10(safeVolume) * 20);
    //    PlayerPrefs.SetFloat("Turntable_Volume", volume);
    //}
}
