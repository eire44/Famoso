using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform[] playerPositions;
    public GameObject[] rooms_PaintableObjects;
    public Transform player;
    Doors_Controller doors_controller;
    Dialogs_Controller dialogs_controller;
    int roomIndex = 0;
    scenes_progression scenes_Progression;

    public AudioSource audioSource_Click;
    public string nombreEscena = "MainMenu";
    bool gameEnded = false;
    private void Start()
    {
        doors_controller = FindObjectOfType<Doors_Controller>();
        dialogs_controller = FindObjectOfType<Dialogs_Controller>();
        doors_controller.paintableObjects = rooms_PaintableObjects[roomIndex];
        player.position = playerPositions[roomIndex].position;
        scenes_Progression = FindObjectOfType<scenes_progression>();


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        dialogs_controller.changeDialogsSet(roomIndex);
        //dialogs_controller.startMonologue();
    }

    public void changeRoom()
    {
        if (gameEnded) return;

        roomIndex++;
        Debug.Log("new room number " + roomIndex);
        if (roomIndex < rooms_PaintableObjects.Length)
        {
            Debug.Log("entered next room");
            doors_controller.paintableObjects = rooms_PaintableObjects[roomIndex];

            CharacterController cc = player.GetComponent<CharacterController>();

            if (cc != null) cc.enabled = false;

            player.position = playerPositions[roomIndex].position;

            if (cc != null) cc.enabled = true;

            dialogs_controller.changeDialogsSet(roomIndex);
        }
        else
        {
            gameEnded = true;
            Debug.Log("ending starting");

            UI_Controller.gameCompleted = true;
            scenes_Progression.triggerHideWorld();
        }
    }
    public void Jugar()
    {
        audioSource_Click.Play();
        SceneManager.LoadScene(nombreEscena);
    }
}
