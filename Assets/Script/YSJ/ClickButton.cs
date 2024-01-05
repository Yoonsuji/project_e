using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject gameCanvas;
    public GameObject Check;
    public float smoothTime = 0.5f;
    public float shrinkSpeed = 1.5f;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Move);
    }
    void Move()
    {
        Check.SetActive(true);
        Invoke("ActivateCheck", 3f);
    }
    void ReplayClick()
    {
        gameOverCanvas.SetActive(true);
        gameCanvas.SetActive(false);

    }
}
