using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpenSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Open", 0.1f);
    }
    void Open()
    {
        this.GetComponent<AudioSource>().Play();
    }
}
