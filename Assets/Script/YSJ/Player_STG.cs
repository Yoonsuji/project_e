using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Player_STG : MonoBehaviour
{
    Animator animator;

    public float moveSpeed = 1.0f;
    public float lerpTime = 0.5f;

    public Button button1;
    public Transform PlayerTarget;
    public Canvas ClearCanvas;
    public Canvas GameCanvas;
    void Start()
    {
        button1.onClick.AddListener(OnButtonClick);
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    void OnButtonClick()
    {
        StartCoroutine(Move());
    }
    private IEnumerator Move()
    {
        animator.SetBool("isWalk", true);
        yield return new WaitForSeconds(2f);

        while (Vector2.Distance(transform.position, PlayerTarget.position) > 0.1f)
        {
            transform.position = Vector2.Lerp(transform.position, PlayerTarget.position, lerpTime * Time.deltaTime);
            yield return null;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Wall"))
        {
            Debug.Log("Wall");
            ClearCanvas.enabled = true;
            GameCanvas.enabled = false;
        }
    }
    
    
}

