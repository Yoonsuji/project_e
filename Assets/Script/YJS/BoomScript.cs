using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    void Start()
    {
        audioSource.Play();
        Invoke("BoomDestroy", 0.5f);
    }
    void BoomDestroy()
    {
        Destroy(this.gameObject);
    }
}
