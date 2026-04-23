using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    //public AudioSource audioSource_Click;

    public Transform pInicio;
    public Transform pCreditos;
    //public Transform pOpciones;

    public string nombreEscena;

    public void Jugar()
    {
        //audioSource_Click.Play();
        SceneManager.LoadScene(nombreEscena);
    }

    public void Salir()
    {
        //audioSource_Click.Play();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                                            Application.Quit();
        #endif
    }

    public void irACreditos()
    {
        //audioSource_Click.Play();
        pInicio.gameObject.SetActive(false);
        pCreditos.gameObject.SetActive(true);
    }

    public void irAOpciones()
    {
        //audioSource_Click.Play();
        pInicio.gameObject.SetActive(false);
        //pOpciones.gameObject.SetActive(true);
    }

    public void volverAlMenu()
    {
        //audioSource_Click.Play();
        pInicio.gameObject.SetActive(true);
        //pOpciones.gameObject.SetActive(false);
        pCreditos.gameObject.SetActive(false);
    }
}
