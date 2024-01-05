using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTower : MonoBehaviour
{
    public CameraMove Camera;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<TowerBox>() && Camera.isFirst == false)
        {
            print("dd");
        }
    }
}
