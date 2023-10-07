using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    public float mouseZoomSpeed = 10.0f;
    public float touchZoomSpeed = 10.0f;
    public float minZoom = 1.0f;
    public float maxZoom = 100.0f;

    private float currentZoom = 10.0f;

    void Update()
    {
        // Get the mouse wheel scroll and touch input.
        float mouseZoomInput = Input.GetAxis("Mouse ScrollWheel");
        float touchZoomInput = Input.GetTouch(0).deltaPosition.x;

        // Calculate the new zoom level.
        float newZoom = currentZoom + mouseZoomInput * mouseZoomSpeed * Time.deltaTime + touchZoomInput * touchZoomSpeed * Time.deltaTime;

        // Clamp the zoom level within the min and max zoom values.
        newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);

        // Set the camera's zoom level.
        currentZoom = newZoom;

        // Apply the zoom level to the camera.
        Camera.main.orthographicSize = currentZoom;
    }
}
