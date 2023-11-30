using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    public Transform player;
    private float xMouse;
    private float yMouse;
    private float xRotation;
    public float Speed = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        xMouse = Input.GetAxis("Mouse X") * Speed * Time.deltaTime;
        yMouse = Input.GetAxis("Mouse Y") * Speed * Time.deltaTime;
        xRotation -= yMouse;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * xMouse); 
    }
}
