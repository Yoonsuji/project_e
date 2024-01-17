using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private float currentVelocity;
    public float moveSpeed = 5f;
    public float smoothTime = 0.1f;

    public Button LeftButton;
    public Button RightButton;

    public bool inputLeft = false;
    public bool inputRight = false;

    Rigidbody2D rigid;
    Animator animator;

    public void Start()
    {
        LeftButton.onClick.AddListener(MoveLeft);
        RightButton.onClick.AddListener(MoveRight);
    }

    void MoveLeft()
    {
        float targetX = transform.position.x - moveSpeed;
        SmoothMove(targetX);
    }
    void MoveRight()
    {
        float targetX = transform.position.x + moveSpeed;
        SmoothMove(targetX);
    }
    void SmoothMove(float targetX)
    {
        float newPositionX = Mathf.SmoothDamp(transform.position.x, targetX, ref currentVelocity, smoothTime);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
