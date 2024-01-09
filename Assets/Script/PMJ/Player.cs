using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using TreeEditor;
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
    public bool istransform;

    public float speed;
    public float clearCount;
    public float moveSpeed = 5f;

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
        //isGround = IsGrounded();
        Move();
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
        if (isRingOut && !istransform)
        {
            anim.SetBool("isWalk", true);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);

        }
        /*
         * if (!hasArrived && isRingOut)
        {
            // 현재 위치와 목표 위치 간의 거리 계산
            float distance = Vector3.Distance(transform.position, targetPosition.position);

            // 목표 지점에 도착하지 않았다면 계속 이동
            if (distance > arrivalDistance)
            {
                // 타겟 위치 방향으로 플레이어를 부드럽게 이동
                transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
                anim.SetBool("isWalk", true); // 이동 중 애니메이션 실행
            }
            else
            {
                hasArrived = true;
                anim.SetBool("isWalk", false); // 이동 중 애니메이션 멈춤
                // 목표 지점에 도착했을 때 움직임 멈춤
                // Optional: 여기에 움직임을 멈추도록 추가 코드를 작성할 수 있습니다.
                // 예를 들어, 애니메이션을 멈추거나 다른 동작을 추가할 수 있습니다.
            }
        }
        */
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

        else if(collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            GameManager.instance.diePanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            isClear = true;
            StartCoroutine(Clear());
        }

        else if(collision.gameObject.CompareTag("Transform"))
        {
            istransform = true;
            anim.SetBool("isWalk", false);
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
