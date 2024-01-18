using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Poo : MonoBehaviour
{
    Animator animator;
    public bool LeftMove = false;
    public bool RightMove = false;
    public GoodsPrefab goodsPrefab;
    public TextMeshProUGUI CoinText;
    Vector3 moveVelocity = Vector3.zero;
    private SpriteRenderer playerSpriteRenderer;
    public float moveSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
         
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            
        }
    }
    void FixedUpdate()
    {
        if(LeftMove)
        {
            animator.SetBool("isWalk", true);
            playerSpriteRenderer.flipX = true;
            moveVelocity = new Vector3(-0.10f, 0, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;
        }
        if(RightMove)
        {
            animator.SetBool("isWalk", true);
            playerSpriteRenderer.flipX = false;
            moveVelocity = new Vector3(+0.10f, 0, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;
        }
    }
    
}
