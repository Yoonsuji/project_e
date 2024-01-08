using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    Animator anim;
    Rigidbody2D rigid;
    SpriteRenderer renderer;
    CapsuleCollider2D capsule;

    public bool isDie;
    public bool isRingOut;
    public bool isClear;
    public bool isGround;
    public float speed;
    public float clearCount;
    public float rayDistance;

    public Transform targetPosition;
    // Start is called before the first frame update
    private void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        renderer= GetComponent<SpriteRenderer>();
        capsule= GetComponent<CapsuleCollider2D>();

        if (instance == null) { instance = this; }
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        isGround = IsGrounded();
        Move();
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
    
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Fruit"))
            {
                StartCoroutine(Clear());
                Debug.Log("플레이어가 과일과 충돌했습니다!");
            }
        }
    }

    private void Move()
    {
        /*if (!isDie && isRingOut)
        {
            if (!isGround || isClear)
            {
                anim.SetBool("isWalk", false);
                rigid.velocity = new Vector2(0, 0f);
            }

            else if(isRingOut)
            {
                anim.SetBool("isWalk", true);
                rigid.velocity = new Vector2(speed, 0);
            }
        }*/
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
    }
    IEnumerator Clear()
    {
        yield return new WaitForSeconds(clearCount);
        GameManager.instance.clearPanel.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        /*
        if (collision.gameObject.CompareTag("Wall"))
        {
            speed = -speed;
            renderer.flipX = renderer.flipX ? false : true;
        }
        */

        if(collision.gameObject.CompareTag("Metaball_liquid") || collision.gameObject.CompareTag("Metaball_liquid2"))
        {
            rigid.velocity = new Vector2(0, 0);
            capsule.isTrigger = true;
            rigid.bodyType = RigidbodyType2D.Kinematic;
            string collisionTag = collision.gameObject.tag;
            GameManager.instance.StartCoroutine(GameManager.instance.FadeOut(gameObject, collisionTag));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            isClear = true;
            StartCoroutine(Clear());
        }
    }

    private bool IsGrounded()
    {
        // 플레이어 아래의 Raycast를 쏘아 바닥과 충돌하는지 여부 확인
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        if (hit.collider != null)
        {
            return true; // 바닥에 닿았음
        }
        else
        {
            return false; // 바닥에 닿지 않았음
        }
    }
}
