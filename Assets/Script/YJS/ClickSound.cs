using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioSource clickSound;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickSound.Play();
        }
    }
}
