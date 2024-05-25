using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera LeftCamera;
    public CinemachineVirtualCamera RightCamera;
    public CinemachineVirtualCamera MainCamera;

    // Zoom Kontrolü
    public Camera playerCamera;
    public float zoomSpeed = 2f;
    public float minZoom = 20f;
    public float maxZoom = 60f;

    private void HandleZoom()
    {
        float scrollData = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log("Scroll Data: " + scrollData);  // Debug line to check scroll input

        if (scrollData != 0f)  // Check if there is any scroll input
        {
            playerCamera.fieldOfView -= scrollData * zoomSpeed;
            playerCamera.fieldOfView = Mathf.Clamp(playerCamera.fieldOfView, minZoom, maxZoom);
            Debug.Log("Updated FOV: " + playerCamera.fieldOfView);  // Debug line to check updated FOV
        }
    }

    public void SetCam(cameraTypes camera)
    {
        if (camera == cameraTypes.main)
        {
            MainCamera.Priority = 11;
            LeftCamera.Priority = 0;
            RightCamera.Priority = 1;
        }
        else if (camera == cameraTypes.left)
        {
            MainCamera.Priority = 0;
            LeftCamera.Priority = 11;
            RightCamera.Priority = 1;
        }
        else if (camera == cameraTypes.right)
        {
            MainCamera.Priority = 1;
            LeftCamera.Priority = 0;
            RightCamera.Priority = 11;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (playerCamera == null)
        {
            Debug.LogError("Player Camera is not assigned!");  // Debug line for missing camera assignment
        }
    }

    int sayac = 1000;

    // Update is called once per frame
    void Update()
    {
        // Zoom Kontrolü
        HandleZoom();

        if (Input.GetKeyDown(KeyCode.P))
        {
            sayac++;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            sayac--;
        }

        if (sayac % 3 == 0)
        {
            SetCam(cameraTypes.right);
        }
        else if (sayac % 3 == 1)
        {
            SetCam(cameraTypes.main);
        }
        else if (sayac % 3 == 2)
        {
            SetCam(cameraTypes.left);
        }
    }
}

public enum cameraTypes
{
    main,
    left,
    right
}
