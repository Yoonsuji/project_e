using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    void Start()
    {
        Invoke("BoomDestroy", 7f);
    }
    void BoomDestroy()
    {
        Destroy(this.gameObject);
    }
}
