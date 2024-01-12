using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    public bool isDie;
    public bool die;
    public GameObject ghost;
    GameObject[] water;

    protected Rigidbody2D rigid;
    protected CapsuleCollider2D capsule;
    protected SpriteRenderer renderer;
    protected Animator anim;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        capsule = GetComponent<CapsuleCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDie) StartCoroutine(Die());
    }
    /*
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
    */
    private void FixedUpdate()
    {
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {

                    anim.SetBool("isDown", false);
                    Debug.Log(rayHit.collider.name);
                }

            }
            else anim.SetBool("isDown", true);
        }
    }
    protected IEnumerator Die()
    {
        if (!die)
        {
            die = true;
            anim.SetTrigger("Die");
            yield return new WaitForSeconds(1f);
            ghost.SetActive(true);
            yield return new WaitForSeconds(1f);
            ghost.SetActive(false);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Metaball_liquid") || collision.gameObject.CompareTag("Metaball_liquid2"))
        {
            isDie = true;
            rigid.velocity = new Vector2(0, 0);
            capsule.isTrigger = true;
            rigid.bodyType = RigidbodyType2D.Kinematic;

            //water = GameObject.FindGameObjectsWithTag("Metaball_liquid");
            //GameManager.instance.StartCoroutine(Fadeout(gameObject, collision));
            //GameManager.instance.FadeOut(gameObject, collision);
            string collisionTag = collision.gameObject.tag;
            GameManager.instance.StartCoroutine(GameManager.instance.FadeOut(gameObject, collisionTag));
            //gameObject.SetActive(false);
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            rigid.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            anim.SetBool("isDown", false);

        }
    }
}