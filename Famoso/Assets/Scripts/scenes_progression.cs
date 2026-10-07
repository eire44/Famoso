using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class scenes_progression : MonoBehaviour
{
    [SerializeField] Image blackScreen;
    [SerializeField] GameObject ContentWarning;
    [SerializeField] TMP_Text progressionSentence;
    [SerializeField] string startingSentence = "Take your time, immerse in your thoughts.";
    [SerializeField] string endingSentence = "Whenever I lose myself, in art I find me.";
    [SerializeField] float shadowDuration = 10f;
    [SerializeField] GameObject gameCompletedScreen;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject handySlots;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        triggerShowWorld();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
             pauseMenu.SetActive(!pauseMenu.activeSelf);
             Time.timeScale = pauseMenu.activeSelf ? 0f : 1f;
        }
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
        ContentWarning.SetActive(true);
        float timer = 0f;

        blackScreen.color = new Color(0f, 0f, 0f, 1f);

        while (timer < shadowDuration)
        {
            timer += Time.unscaledDeltaTime;
            yield return null;
        }

        ContentWarning.SetActive(false);

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
        HUD.SetActive(false);
        handySlots.SetActive(false);
        Time.timeScale = 0f;
        blackScreen.gameObject.SetActive(true);
        blackScreen.color = new Color(0f, 0f, 0f, 1f);
        float timer = 0f;

        while (timer < shadowDuration)
        {
            timer += Time.unscaledDeltaTime;

            yield return null;
        }

        Time.timeScale = 1f;
        gameCompletedScreen.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        blackScreen.gameObject.SetActive(false);
        blackScreen.color = new Color(0f, 0f, 0f, 0f);
    }

    IEnumerator showSentence(string sentence)
    {
        progressionSentence.text = sentence;
        progressionSentence.gameObject.SetActive(true);
        progressionSentence.color = new Color(1f, 1f, 1f, 1f);
        float timer = 0f;

        while (timer < shadowDuration)
        {
            timer += Time.unscaledDeltaTime;

            yield return null;
        }


        progressionSentence.color = new Color(1f, 1f, 1f, 0f);
        progressionSentence.gameObject.SetActive(false);
    }

    public void btnPauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = pauseMenu.activeSelf ? 0f : 1f;
    }
}
