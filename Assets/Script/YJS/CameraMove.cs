using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class CameraMove : MonoBehaviour
{
    public Transform targetPosition;
    public float smoothTime = 0.3f;
    public TowerManager towerManager;
    private Vector3 velocity = Vector3.zero;
    public bool isActive = false;
    public bool isFirst = true;
    public int i = 1;


    public void LoadStart()
    {
        isActive = true;
        targetPosition.transform.Translate(new Vector3(2.7f * ((float)towerManager.excel.Count - 1f)+0.4f, 0f, -10f));
    }

    private void Update()
    {
        if (isActive)
        {
            Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, targetPosition.position, ref velocity, smoothTime);

            if (Vector3.Distance(targetPosition.position, Camera.main.transform.position) < 0.01f)
            {
                isActive = false;
                this.transform.position = new Vector3(targetPosition.position.x, 0f, -10f);
            }
        }
        float ccc = Mathf.Abs(this.transform.position.x - targetPosition.transform.position.x);
        if (Mathf.Abs(this.transform.position.x - targetPosition.transform.position.x) < 0.1f && isFirst==true)
        {
            isActive = true;
            isFirst = false;
            targetPosition.transform.position = new Vector3(0f, 0f, -10f);
        }
    }
    public void NextTower()
    {
        targetPosition.transform.position = new Vector3(2.7f*i, 0f, -10f);
        isActive = true;
        i++;
    }
}
