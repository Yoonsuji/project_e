using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BoomDestroy", 0.5f);
    }
    void BoomDestroy()
    {
        Destroy(this.gameObject);
    }
}
