using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_test : MonoBehaviour
{
    public Transform targetTransform;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if(hit.collider != null)
            {
                GameObject click_obj = hit.transform.gameObject;
                targetTransform.position = new Vector3(0, 0, 0);
                Debug.Log(click_obj.name);
            }
        }
    }
}
