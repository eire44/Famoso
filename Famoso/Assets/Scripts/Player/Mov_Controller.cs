using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Controller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = -9.81f;

    [HideInInspector] public float mouseSensitivity = 300f;
    public Transform cameraTransform;

    private float xRotation = 0f;
    private Vector3 velocity;
    private CharacterController controller;

    Vector3 startPosition;
    public float fallLimit = -10f;

    void Start()
    {
        startPosition = transform.position;
        controller = GetComponent<CharacterController>();
        mouseSensitivity = PlayerPrefs.GetFloat("Sensitivity", 300f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveSpeed = 12f;
        }
        else
        {
            moveSpeed = 8f;
        }

        //if (transform.position.y < fallLimit)
        //{
        //    Respawn();
        //}

        Move();
        Look();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void Respawn()
    {
        CharacterController cc = GetComponent<CharacterController>();

        if (cc != null)
            cc.enabled = false;

        transform.position = startPosition;

        if (cc != null)
            cc.enabled = true;
    }
}
