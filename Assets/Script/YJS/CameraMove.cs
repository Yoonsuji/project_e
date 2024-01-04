using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform targetPosition;

    public float smoothTime = 0.3f;

    public TowerManager towerManager;

    public GameObject Point;

    private Vector3 velocity = Vector3.zero;

    public bool isActive = false;


    private void Start()
    {
        isActive = true;
        Point.transform.Translate(new Vector3(2.7f*(float)towerManager.excel.Count, 0f, -10f));
    }

    private void Update()
    {
        if (isActive)
        {
            Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, targetPosition.position, ref velocity, smoothTime);

            if (Vector3.Distance(targetPosition.position, Camera.main.transform.position) < 0.1f)
            {
                isActive = false;
            }
        }
        if (this.transform.position == Point.transform.position)
        {
            
        }
    }
}
