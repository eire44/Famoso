using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DoorScript;
using System;
using UnityEditor.Rendering;

public class Dialogs_Controller : MonoBehaviour
{
    public List<DialogsSet> dialogs = new List<DialogsSet>();
    public TMP_Text txtDialogs;
    public TMP_Text txtIndications;
    public TMP_Text txtInstructions;
    int dialogIndex = 0;

    public float timeBetweenLines = 3f;
    public float typingSpeed = 0.02f;
    bool isTyping = false;
    Coroutine dialogueCoroutine;
    MO_TexturesController MO_TexturesController;

    [HideInInspector] public bool MO_ShowOutline = false;
    [HideInInspector] public bool PO_ShowOutline = false;
    [HideInInspector] public bool Ch_ShowOutline = false;
    [HideInInspector] public bool Do_ShowOutline = false;

    private void Start()
    {
        MO_TexturesController = FindObjectOfType<MO_TexturesController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Doors"))
            {
                Do_ShowOutline = true;
                MO_ShowOutline = false;
                PO_ShowOutline = false;
                Ch_ShowOutline = false;
                showInstructions("Press E to open");
            } else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Characters"))
            {
                Ch_ShowOutline = true;
                MO_ShowOutline = false;
                PO_ShowOutline = false;
                Do_ShowOutline = false;
                txtInstructions.gameObject.SetActive(false);
                CharactersTexts characterSign = hit.collider.gameObject.GetComponent<CharactersTexts>();
                if (characterSign != null)
                {
                    showIndication(characterSign.signIndicationText);
                }
            }
            else
            {
                txtDialogs.gameObject.SetActive(true);
                txtIndications.gameObject.SetActive(false);

                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Memorable Objects"))
                {
                    MO_ShowOutline = true;
                    PO_ShowOutline = false;
                    Ch_ShowOutline = false;
                    Do_ShowOutline = false;
                    showInstructions("Press E to save pattern");
                }
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Paintable Objects"))
                {
                    PO_ShowOutline = true;
                    MO_ShowOutline = false;
                    Ch_ShowOutline = false;
                    Do_ShowOutline = false;
                    showInstructions("Press E to paint");
                }
                else
                {
                    MO_ShowOutline = false;
                    PO_ShowOutline = false;
                    Ch_ShowOutline = false;
                    Do_ShowOutline = false;
                    txtInstructions.gameObject.SetActive(false);
                }
            }
        }
    }

    public void showInstructions(string instructionsText)
    {
        if(!MO_TexturesController.showingInventoryText)
        {
            txtInstructions.gameObject.SetActive(true);
            txtInstructions.text = instructionsText;
        }
    }

    public void changeDialogsSet(int roomIndex)
    {
        if (dialogueCoroutine != null)
            StopCoroutine(dialogueCoroutine);

        dialogIndex = 0;
        dialogueCoroutine = StartCoroutine(ShowDialogue(dialogs[roomIndex].dialogsSet));
    }

    public void showIndication (string indicationText)
    {
        txtDialogs.gameObject.SetActive(false);
        txtIndications.gameObject.SetActive(true);
        txtIndications.text = indicationText;
    }

    IEnumerator ShowDialogue(string[] currentDialogsSet)
    {
        while (dialogIndex < currentDialogsSet.Length)
        {
            yield return StartCoroutine(TypeLine(currentDialogsSet[dialogIndex]));

            float timer = 0f;
            while (timer < timeBetweenLines)
            {
                if (!txtDialogs.gameObject.activeInHierarchy)
                {
                    yield return null;
                    continue;
                }
                timer += Time.deltaTime;

                if (Input.GetKeyDown(KeyCode.Space))
                    break;

                yield return null;
            }

            dialogIndex++;
        }

        txtDialogs.text = "";
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        txtDialogs.text = "";

        foreach (char c in line)
        {
            while (!txtDialogs.gameObject.activeInHierarchy)
                yield return null;

            txtDialogs.text += c;
            yield return new WaitForSeconds(typingSpeed);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                txtDialogs.text = line;
                break;
            }
        }

        isTyping = false;
    }
}
