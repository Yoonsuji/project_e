using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMove : MonoBehaviour
{
    public Transform targetObject;
    public Camera camera;
    public Vector3 offset = new Vector3(0f, 0.5f, 0f);

    void Update()
    {
        if (targetObject != null)
        {
            Vector3 targetPosition = targetObject.position + offset;
            transform.position = Camera.main.WorldToScreenPoint(targetPosition);
        }
    }
}
