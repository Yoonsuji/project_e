using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector2 dir;

    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
        rigid.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            speed = -speed;
        }
    }
}