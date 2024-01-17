using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelClick : MonoBehaviour
{
    public Canvas GameCanvas;
    public GameObject Circle;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameCanvas.gameObject.SetActive(true);
            Circle.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
