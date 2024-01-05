using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;
    SpriteRenderer renderer;

    public bool isDie;
    public float speed;

    // Start is called before the first frame update
    private void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        renderer= GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        anim.SetBool("isWalk", true);
        if (!isDie) rigid.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            speed = -speed;
            renderer.flipX = renderer.flipX ? false : true;
        }
    }
}
