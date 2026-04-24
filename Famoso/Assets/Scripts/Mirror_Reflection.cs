using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror_Reflection : MonoBehaviour
{
    Transform playerCamera;
    Transform mirrorPlane;
    Camera mirrorCamera;

    private void Start()
    {
        //no funciona
        playerCamera = Camera.main.transform;
        mirrorPlane = transform;
        mirrorCamera = GetComponentInChildren<Camera>();
    }

    void LateUpdate()
    {
        Vector3 normal = mirrorPlane.forward;

        Vector3 camPos = playerCamera.position;
        Vector3 toPlane = camPos - mirrorPlane.position;

        Vector3 reflectedPos = camPos - 2f * Vector3.Dot(toPlane, normal) * normal;
        mirrorCamera.transform.position = reflectedPos;

        Vector3 forward = Vector3.Reflect(playerCamera.forward, normal);
        Vector3 up = Vector3.Reflect(playerCamera.up, normal);

        mirrorCamera.transform.rotation = Quaternion.LookRotation(forward, up);
    }
}
