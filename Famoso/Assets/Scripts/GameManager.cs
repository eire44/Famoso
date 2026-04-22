using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] playerPositions;
    public GameObject[] rooms_PaintableObjects;
    public Transform player;
    Doors_Controller doors_controller;
    int roomIndex = 0;

    private void Start()
    {
        doors_controller = FindObjectOfType<Doors_Controller>();
        doors_controller.paintableObjects = rooms_PaintableObjects[roomIndex];
        player.position = playerPositions[roomIndex].position;
    }

    public void changeRoom()
    {
        roomIndex++;
        doors_controller.paintableObjects = rooms_PaintableObjects[roomIndex];
        //player.position = playerPositions[roomIndex].position;

        CharacterController cc = player.GetComponent<CharacterController>();

        if (cc != null) cc.enabled = false;

        player.position = playerPositions[roomIndex].position;

        if (cc != null) cc.enabled = true;
    }
}
