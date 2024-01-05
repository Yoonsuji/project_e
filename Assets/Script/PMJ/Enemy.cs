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

    protected Rigidbody2D rigid;
    protected CapsuleCollider2D capsule;
    protected SpriteRenderer renderer;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        capsule = GetComponent<CapsuleCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected IEnumerator Fadeout()
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

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Metaball_liquid"))
        {
            die= true;
            rigid.velocity = new Vector2(0, 0);
            capsule.isTrigger = true;
            rigid.bodyType = RigidbodyType2D.Kinematic;
            water = GameObject.FindGameObjectsWithTag("Metaball_liquid");
            StartCoroutine(Fadeout());
            //gameObject.SetActive(false);
        }
    }
}