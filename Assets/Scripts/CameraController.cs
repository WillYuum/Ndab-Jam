using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    private float zoomLerpSpeed = 10;


    public float minZoom;
    public float maxZoom;
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = minZoom;
    }

    //private bool zoomedOut = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, maxZoom, Time.deltaTime * zoomLerpSpeed);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, minZoom, Time.deltaTime * zoomLerpSpeed);
        }
    }
}
