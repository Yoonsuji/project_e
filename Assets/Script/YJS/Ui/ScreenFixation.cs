using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFixation : MonoBehaviour
{
    private Camera mainCam;
    void Start() 
    {
        mainCam = Camera.main;
        var camera = mainCam;
        var r = camera.rect; 
        var scaleheight = ((float)Screen.width / Screen.height) / (720f / 1280f); 
        var scalewidth = 1f / scaleheight; 
        if (scaleheight < 1f) 
        { 
            r.height = scaleheight; 
            r.y = (1f - scaleheight) / 2f;
        } 
        else 
        { 
            r.width = scalewidth; 
            r.x = (1f - scalewidth) / 2f; 
        } 
        camera.rect = r;
    }
    void OnPreCull() => GL.Clear(true, true, Color.black);
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
