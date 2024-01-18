using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelClick : MonoBehaviour
{
    public Canvas GameCanvas;
    public GameObject Circle;
    public AudioClip audioClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (gameObject != null)
            {
                audioSource.Play();
            }
            Invoke("NextStep", 0.5f);
            audioSource.clip = audioClip;
        }
    }
    void NextStep()
    {
        GameCanvas.gameObject.SetActive(true);
        Circle.SetActive(true);
        gameObject.SetActive(false);
    }
}
