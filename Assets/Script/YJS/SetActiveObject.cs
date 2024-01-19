using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveObject : MonoBehaviour
{
    public GameObject gameObject;
    public void ActiveObject()
    {
        if (gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
