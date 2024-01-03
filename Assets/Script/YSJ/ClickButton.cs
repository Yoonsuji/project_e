     using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject gameCanvas;
    public float smoothTime = 0.5f;
    public float shrinkSpeed = 1.5f;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ReplayClick);
    }
    void ReplayClick()
    {
        gameOverCanvas.SetActive(true);
        gameCanvas.SetActive(false);

    }
}
