using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] playerPositions;
    public GameObject[] rooms_PaintableObjects;
    public Transform player;
    Doors_Controller doors_controller;
    Dialogs_Controller dialogs_controller;
    int roomIndex = 0;

    private void Start()
    {
        doors_controller = FindObjectOfType<Doors_Controller>();
        dialogs_controller = FindObjectOfType<Dialogs_Controller>();
        doors_controller.paintableObjects = rooms_PaintableObjects[roomIndex];
        player.position = playerPositions[roomIndex].position;


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        dialogs_controller.changeDialogsSet(roomIndex);
        //dialogs_controller.startMonologue();
    }

    public void changeRoom()
    {
        if (roomIndex < rooms_PaintableObjects.Length)
        {
            roomIndex++;
            doors_controller.paintableObjects = rooms_PaintableObjects[roomIndex];

            CharacterController cc = player.GetComponent<CharacterController>();

            if (cc != null) cc.enabled = false;

            player.position = playerPositions[roomIndex].position;

            if (cc != null) cc.enabled = true;

            dialogs_controller.changeDialogsSet(roomIndex);
        }
        else
        {
            //abrir fin del juego
        }
    }
}
