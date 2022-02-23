using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    enum Cameras { orbital, shoulder, free };

    [SerializeField] private GameObject shoulderCam;

    [SerializeField] private GameObject freeCam;

    [SerializeField] private GameObject orbitalCam;

    Cameras currentCamera;

    private Transform orbitalOrigin;

    private Transform freeOrigin;

    Cameras lastCamera;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        orbitalOrigin = orbitalCam.transform;

        freeOrigin = freeCam.transform;

        currentCamera = Cameras.orbital;
        orbitalCam.SetActive(true);
        shoulderCam.SetActive(false);
        freeCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            switch (currentCamera)
            {
                case Cameras.orbital:
                    orbitalCam.SetActive(false);
                    shoulderCam.SetActive(true);
                    freeCam.SetActive(false);
                    currentCamera = Cameras.shoulder;

                    break;
                case Cameras.shoulder:
                    freeCam.transform.position = freeOrigin.position;
                    freeCam.transform.rotation = freeOrigin.rotation;
                    orbitalCam.SetActive(false);
                    shoulderCam.SetActive(false);
                    freeCam.SetActive(true);
                    currentCamera = Cameras.free;
                    break;
                case Cameras.free:
                    orbitalCam.transform.position = orbitalOrigin.position;
                    orbitalCam.SetActive(true);
                    shoulderCam.SetActive(false);
                    freeCam.SetActive(false);
                    currentCamera = Cameras.orbital;
                    break;
                default:
                    orbitalCam.SetActive(true);
                    shoulderCam.SetActive(false);
                    freeCam.SetActive(false);
                    currentCamera = Cameras.orbital;
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            lastCamera = currentCamera;
            orbitalCam.SetActive(false);
            shoulderCam.SetActive(false);
            freeCam.SetActive(true);
            currentCamera = Cameras.shoulder;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if(lastCamera == Cameras.orbital)
            {
                orbitalCam.SetActive(true);
                shoulderCam.SetActive(false);
                freeCam.SetActive(false);
                currentCamera = lastCamera;
            }
            else if (lastCamera == Cameras.shoulder)
            {
                orbitalCam.SetActive(false);
                shoulderCam.SetActive(true);
                freeCam.SetActive(false);
                currentCamera = lastCamera;
            }
        }
    }
}
