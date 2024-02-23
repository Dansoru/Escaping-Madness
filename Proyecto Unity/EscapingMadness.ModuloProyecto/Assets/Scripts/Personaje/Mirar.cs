using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirar : MonoBehaviour
{
    public float sensRaton = 100f;

    public Transform cuerpoPersonaje;

    float xRotation = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        float ratonX = Input.GetAxis("Mouse X") * sensRaton * Time.deltaTime;
        float ratonY = Input.GetAxis("Mouse Y") * sensRaton * Time.deltaTime;

        xRotation -= ratonY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        cuerpoPersonaje.Rotate(Vector3.up * ratonX);
    }
}
