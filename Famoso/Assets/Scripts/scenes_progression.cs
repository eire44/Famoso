using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class scenes_progression : MonoBehaviour
{
    public Image blackScreen;
    public TMP_Text progressionSentence;
    public string startingSentence = "Take your time, immerse in your thoughts.";
    public string endingSentence = "Whenever I lose myself, in art I find me.";
    public float shadowDuration = 10f;
    public GameObject gameCompletedScreen;
    public GameObject HUD;
    public GameObject handySlots;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        triggerShowWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerShowWorld()
    {
        StartCoroutine(showWorld());
        StartCoroutine(hideSentence(startingSentence));
    }

    public void triggerHideWorld()
    {
        StartCoroutine(hideWorld()); 
        StartCoroutine(showSentence(endingSentence));
    }

    IEnumerator showWorld()
    {
        blackScreen.gameObject.SetActive(true);
        float timer = 0f;

        blackScreen.color = new Color(0f, 0f, 0f, 1f);

        while (timer < shadowDuration)
        {
            timer += Time.unscaledDeltaTime;
            yield return null;
        }

        blackScreen.color = new Color(0f, 0f, 0f, 0f);
        blackScreen.gameObject.SetActive(false);
        Time.timeScale = 1f;
        HUD.SetActive(true);
        handySlots.SetActive(true);
    }
    IEnumerator hideSentence(string sentence)
    {
        progressionSentence.text = sentence;
        progressionSentence.gameObject.SetActive(true);
        float timer = 0f;

        progressionSentence.color = new Color(1f, 1f, 1f, 1f);

        while (timer < shadowDuration)
        {
            timer += Time.unscaledDeltaTime;

            yield return null;
        }

        progressionSentence.color = new Color(1f, 1f, 1f, 0f);
        progressionSentence.gameObject.SetActive(false);
    }

    IEnumerator hideWorld()
    {
        blackScreen.gameObject.SetActive(true);
        float timer = 0f;

        while (timer < shadowDuration)
        {
            timer += Time.unscaledDeltaTime;

            yield return null;
        }

        blackScreen.color = new Color(0f, 0f, 0f, 1f);
        gameCompletedScreen.SetActive(true);
        blackScreen.gameObject.SetActive(false);
        HUD.SetActive(false);
        handySlots.SetActive(false);
    }

    IEnumerator showSentence(string sentence)
    {
        progressionSentence.text = sentence;
        progressionSentence.gameObject.SetActive(true);
        float timer = 0f;

        while (timer < shadowDuration)
        {
            timer += Time.unscaledDeltaTime;

            yield return null;
        }

        progressionSentence.color = new Color(1f, 1f, 1f, 1f);
        progressionSentence.gameObject.SetActive(false);
    }
}
