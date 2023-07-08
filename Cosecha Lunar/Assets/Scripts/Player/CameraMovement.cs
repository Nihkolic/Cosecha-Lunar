using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 500f; 
    public Transform player;
    public Transform orientation;

    float xRotation = 0.0f;
    float yRotation = 0.0f;

    void Start()
    {
        //PlayerPrefs.SetFloat("Sensitivity", 1f);
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * 80f * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * 80f * Time.deltaTime;

        xRotation -= mouseY; //rotate x axis
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f); // clamp camera rotation up or down

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); 
    }
}
