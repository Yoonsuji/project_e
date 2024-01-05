using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public bool right;
    public bool able;
    public float speed;

    private void Update()
    {
        if(able)
        {
            if(right)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime); 
            }

            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime); 
            }

            Invoke("Hide", 5f);
        }
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
