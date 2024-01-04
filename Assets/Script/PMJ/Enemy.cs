using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    public bool die;

    Rigidbody2D rigid;
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        rigid= GetComponent<Rigidbody2D>();
        renderer= GetComponent<SpriteRenderer>();
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
            renderer.flipX = renderer.flipX ? false : true;
        }

        else if(collision.gameObject.CompareTag("Metaball_liquid"))
        {
            die= true;
            gameObject.SetActive(false);

            GameObject[] water;
            water = GameObject.FindGameObjectsWithTag("Metaball_liquid");
            for (int i = 0; i < water.Length; i++)
            {
                water[i].SetActive(false);
            }
        }
    }
}