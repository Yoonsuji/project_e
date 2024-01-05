using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    public bool die;

    GameObject[] water;

    Rigidbody2D rigid;
    CapsuleCollider2D capsule;
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        rigid= GetComponent<Rigidbody2D>();
        capsule= GetComponent<CapsuleCollider2D>();
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
        if(!die) rigid.velocity = new Vector2(speed, 0);
    }

    IEnumerator Fadeout()
    {
        float fadeCount = 1.0f;
        while(fadeCount > 0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            for(int i = 0; i < water.Length; i++)
            {
                SpriteRenderer renderer = water[i].GetComponent<SpriteRenderer>();
                //Color color= renderer.color;
                // color.a = fadeCount;
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, fadeCount);
            }
        }

        gameObject.SetActive(false);
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
            capsule.isTrigger = true;
            rigid.bodyType = RigidbodyType2D.Kinematic;
            water = GameObject.FindGameObjectsWithTag("Metaball_liquid");
            StartCoroutine(Fadeout());
            //gameObject.SetActive(false);
        }
    }
}