using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    Vector3 mousePosition;
    private Vector3 initialPosition;
    public GameObject nowBox;

    public void Move()
    {
        print("move!!");
    }




    /*private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }
    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
    private void OnMouseUp()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            transform.position = initialPosition;
        }
    }
    */
}
