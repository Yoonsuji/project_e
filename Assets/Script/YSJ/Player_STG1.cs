using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Player_STG1 : MonoBehaviour
{
    Animator animator;

    public float moveSpeed = 1.0f;
    public float lerpTime = 0.5f;

    public Button button1;
    public Transform PlayerTarget;
    public Canvas ClearCanvas2;
    public Canvas GameCanvas;
    void Start()
    {
        button1.onClick.AddListener(OnButtonClick);
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall");
            ClearCanvas2.gameObject.SetActive(true);
            GameCanvas.gameObject.SetActive(false);
        }
    }
    void OnButtonClick()
    {
        StartCoroutine(Move());
    }
    private IEnumerator Move()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("isWalk", true);

        while (Vector2.Distance(transform.position, PlayerTarget.position) > 0.1f)
        {
            transform.position = Vector2.Lerp(transform.position, PlayerTarget.position, lerpTime * Time.deltaTime);
            yield return null;
        }
    }
}

