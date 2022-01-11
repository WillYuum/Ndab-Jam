using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    private float zoomLerpSpeed = 10;

    [SerializeField] private float zoomDuration = 1.0f;

    private bool isZoomedOut = false;

    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;
    void Awake()
    {
        cam = Camera.main;
        cam.orthographicSize = minZoom;
    }

    //private bool zoomedOut = false;
    void Update()
    {
        if (isZoomedOut)
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                CameraZoomIn();
            }
        }


        if (isZoomedOut == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                CameraZoomOut();
            }
        }

    }


    private void CameraZoomOut()
    {
        isZoomedOut = true;
        cam
        .DOOrthoSize(maxZoom, zoomDuration)
        .SetEase(Ease.InOutSine)
        .OnComplete(OnZoomOut);
    }

    private void CameraZoomIn()
    {
        isZoomedOut = false;
        cam
        .DOOrthoSize(minZoom, zoomDuration)
        .SetEase(Ease.InOutSine)
        .OnComplete(OnZoomIn);
    }

    private void OnZoomOut()
    {
        Player.instance.playerControls.SlowDownPlayer();
    }

    private void OnZoomIn()
    {
        Player.instance.playerControls.ResetPlayerSpeed();
    }
}
