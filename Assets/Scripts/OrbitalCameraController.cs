using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCameraController : MonoBehaviour
{
    public GameObject target;
    public float rotationSpeed = 8.0f;

    public float initialZoomDistance = 10.0f;
    private float zoomDistance;
    public float zoomSpeed = 0.5f;
    public float minZoomDistance = 2.0f;
    public float maxZoomDistance = 20.0f;

    private float xRotation = 0;
    private float yRotation = 0;

    void Start()
    {
        zoomDistance = initialZoomDistance;
        transform.position = target.transform.position - transform.forward * zoomDistance;
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            xRotation += Input.GetAxis("Mouse X") * rotationSpeed;
            yRotation += Input.GetAxis("Mouse Y") * rotationSpeed;

            if (yRotation > 90.0f)
                yRotation = 90.0f;
            if (yRotation < -90.0f)
                yRotation = -90.0f;

            transform.rotation = Quaternion.Euler(0, xRotation, 0) * Quaternion.Euler(-yRotation, 0, 0);
        }

        float scrollDirection = Input.GetAxis("Mouse ScrollWheel");
        if (scrollDirection > 0f)
        {
            if(zoomDistance > minZoomDistance && zoomDistance - zoomSpeed >= minZoomDistance)
            {
                zoomDistance -= zoomSpeed;
            }
            else
            {
                zoomDistance = minZoomDistance;
            }
        }
        else if (scrollDirection < 0f && zoomDistance + zoomSpeed <= maxZoomDistance)
        {
            if(zoomDistance < maxZoomDistance)
            {
                zoomDistance += zoomSpeed;
            }
            else
            {
                zoomDistance = maxZoomDistance;
            }
        }

        transform.position = target.transform.position - transform.forward * zoomDistance;
    }
}
