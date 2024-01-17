using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject gameCanvas;
    public GameObject Check;
    public GameObject Paint;
    public Button button1;
    public float smoothTime = 0.5f;
    public float shrinkSpeed = 1.5f;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Move);
    }
    void Move()
    {
        Paint.gameObject.SetActive(false);
        button1.interactable = false;
        Check.SetActive(true);
        Invoke("ReplayClick", 3f);
    }
    void ReplayClick()
    {
        gameOverCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }
}
