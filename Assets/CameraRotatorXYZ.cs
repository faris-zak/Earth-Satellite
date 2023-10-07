using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotatorXYZ : MonoBehaviour
{
    public float mouseSensitivity = 500.0f;
    public float touchSensitivity = 10.0f;
    public float rotationSpeed = 200.0f;

    private bool isRotating = false;
    private Vector2 touchStartPosition;

    void Update()
    {
        // Check if the mouse button is down or the touch screen is pressed.
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            isRotating = true;
            touchStartPosition = Input.GetTouch(0).position;
        }

        // If the mouse button or touch screen is pressed, rotate the camera.
        if (isRotating)
        {
            // Get the mouse or touch movement.
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Calculate the delta touch position.
            Vector2 touchDeltaPosition = Vector2.zero;
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                touchDeltaPosition = Input.GetTouch(0).position - touchStartPosition;
            }

            // Rotate the camera around the z axis based on the mouse or touch horizontal movement.
            transform.Rotate(0.0f, (mouseX + touchDeltaPosition.x) * rotationSpeed * Time.deltaTime, 0.0f);

            // Rotate the camera around the y axis based on the mouse or touch vertical movement.
            transform.Rotate(-(mouseY + touchDeltaPosition.y) * rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
        }

        // Check if the mouse button is up or the touch screen is released.
        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            isRotating = false;
        }
    }
}
