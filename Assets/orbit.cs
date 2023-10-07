using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit : MonoBehaviour
{
    public GameObject satalite;
    public float distance = 0.0f;
    public float speed = 20.0f;

    private float angle = 0.0f;

    void Start()
    {
        transform.position = satalite.transform.position + new Vector3(0.0f, 0.0f, -distance);
        transform.LookAt(satalite.transform);
    }

    void LateUpdate()
    {
        angle += speed * Time.deltaTime;

        var rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        var position = rotation * new Vector3(0.0f, 0.0f, -distance) + satalite.transform.position;

        transform.rotation = rotation;
        transform.position = position;
    }
}