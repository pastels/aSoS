using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("MouseX X") * Time.deltaTime; *sensX;
        float mouseY = Input.GetAxisRaw("MouseX Y") * Time.deltaTime; *sensY;

        yRotation += mouseX;

        xRotation += mouseY;
    }
}
