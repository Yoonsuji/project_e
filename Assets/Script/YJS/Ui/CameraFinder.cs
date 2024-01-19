using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFinder : MonoBehaviour
{
    private Camera maincamera;
    void Start()
    {
        maincamera = FindFirstObjectByType<Camera>();
        this.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        this.GetComponent<Canvas>().worldCamera = maincamera;
    }
}
