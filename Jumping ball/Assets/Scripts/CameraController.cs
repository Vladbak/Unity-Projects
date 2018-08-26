using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;
    public float cameraOffsetX = 0.0f;
    public float cameraOffsetY = 1.0f;
    public float cameraOffsetZ = -5f;

    public float cameraLiftX = 17.0f;

    public float turnSpeed = 4.0f;

    private float rotY = 0.0f; // rotation around the up/y axiss
    private float rotX = 0.0f; // rotation around the right/x axis
    private GameObject Player;
    private Vector3 offset;
    private Vector3 offsetLiftCamera;

    void Start()
    {
        
        Player = GameObject.Find("Player");
        if (Player == null)
            throw new Exception("no plyer found");
        offset = new Vector3(Player.transform.position.x, Player.transform.position.y + cameraOffsetY, Player.transform.position.z + cameraOffsetZ);
    }

    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = Player.transform.position + offset;
        Player.transform.forward = transform.forward;
        transform.LookAt(Player.transform.position);
        transform.localRotation *= Quaternion.Euler(-cameraLiftX, 0.0f, 0.0f);
    }
}
