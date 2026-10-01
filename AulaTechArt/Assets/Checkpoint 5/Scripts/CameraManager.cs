using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject fixedCamera;
    [SerializeField] private GameObject freeCamera;
    [SerializeField] private GameObject spectator;
    
    [SerializeField] private Canvas canvasMessage;
    [SerializeField] private Text textMessage;

    private bool freeCameraActive;

    void Start()
    {
        fixedCamera.SetActive(true);
        freeCamera.SetActive(false);
        spectator.SetActive(false);
        canvasMessage.enabled = false;
        freeCameraActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!freeCameraActive)
            {
                fixedCamera.SetActive(false);
                freeCamera.SetActive(true);
                spectator.SetActive(true);
                freeCameraActive = true;

                textMessage.text = "Your game mode has been updated to Spectator Mode";
                StartCoroutine(EnableCanvas());
            }
            else
            {
                fixedCamera.SetActive(true);
                freeCamera.SetActive(false);
                spectator.SetActive(false);
                freeCameraActive = false;

                textMessage.text = "Your camera has returned to Fixed Mode";
                StartCoroutine(EnableCanvas());
            }
        }
    }

    IEnumerator EnableCanvas()
    {
        canvasMessage.enabled = true;

        yield return new WaitForSeconds(5);

        canvasMessage.enabled = false;
    }
}