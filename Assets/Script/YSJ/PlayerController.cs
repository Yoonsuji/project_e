using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float movePower = 6f;
    public bool inputLeft = false;
    public bool inputRight = false;

    Rigidbody2D rigid;
    Animator animator;

    public void Update()
    {
        if(inputLeft)
        {
            transform.localScale = Vector3.right * movePower * Time.deltaTime;
        }
        else if(inputRight)
        {
            transform.localScale = new Vector3 (1, 1, 1);
        }
    }
}
