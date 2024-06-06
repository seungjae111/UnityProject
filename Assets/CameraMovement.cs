using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(h, v, 0);

        if (Input.GetMouseButton(1)) // Right mouse button held down
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, mouseX);
            transform.Rotate(Vector3.left, mouseY);
        }
    }
}

