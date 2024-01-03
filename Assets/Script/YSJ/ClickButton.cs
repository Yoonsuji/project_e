     using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject gameCanvas;
    void ReplayClick()
    {
        gameOverCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }
}
