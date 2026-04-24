using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_Controller : MonoBehaviour
{
    public AudioSource audioSource_Click;

    public Transform pInicio;
    public Transform pCreditos;
    public TMP_Text gameTitle;
    public TMP_Text gameTitle_Shadow;
    //public Transform pOpciones;

    public string nombreEscena;
    public string startTitle = "The Infinite Obsession with Expressing Myself";
    public string endTitle = "Yayoi´s Mind";
    public static bool gameCompleted = false;

    private void Start()
    {
        if (gameCompleted)
        {
            gameTitle.text = endTitle;
            gameTitle_Shadow.text = endTitle;
        }
        else
        {
            gameTitle.text = startTitle;
            gameTitle_Shadow.text = startTitle;
        }
        
    }

    public void Jugar()
    {
        audioSource_Click.Play();
        SceneManager.LoadScene(nombreEscena);
    }

    public void Salir()
    {
        audioSource_Click.Play();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                                            Application.Quit();
        #endif
    }

    public void irACreditos()
    {
        audioSource_Click.Play();
        pInicio.gameObject.SetActive(false);
        pCreditos.gameObject.SetActive(true);
    }

    public void irAOpciones()
    {
        audioSource_Click.Play();
        pInicio.gameObject.SetActive(false);
        //pOpciones.gameObject.SetActive(true);
    }

    public void volverAlMenu()
    {
        audioSource_Click.Play();
        pInicio.gameObject.SetActive(true);
        //pOpciones.gameObject.SetActive(false);
        pCreditos.gameObject.SetActive(false);
    }
}
