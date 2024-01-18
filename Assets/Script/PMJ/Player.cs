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

    public bool die;
    public bool isDie;
    public bool isRingOut;
    public bool isClear;
    public bool istransform;
    public bool isGround;

    public float speed;
    public float clearCount;
    public float moveSpeed = 5f;

    public Transform targetPosition;
    bool win;
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
        Debug.Log("Log");
    }
    // Update is called once per frame
    void Update()
    {
        //isGround = IsGrounded();
        Move();
        Fall();
    }

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
            else
            {
                anim.SetBool("isDown", true);
                GameManager.instance.SfxPlayer(GameManager.Sfx.Down);
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
        if (isRingOut && !istransform && !isDie)
        {
            GameManager.instance.SfxPlayer(GameManager.Sfx.Walk);

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
    public void Fall()
    {
        //if (!isGround) anim.SetBool("isDown", true);
        //else anim.SetBool("isDown", false);
    }

    IEnumerator Die()
    {
        if (!die)
        {
            //capsule.isTrigger = true;
            //rigid.bodyType = RigidbodyType2D.Kinematic;
            die = true;
            anim.SetTrigger("Die");
            GameManager.instance.SfxPlayer(GameManager.Sfx.PDie);
            yield return new WaitForSeconds(1f);
            gameObject.SetActive(false);
            GameManager.instance.SfxPlayer(GameManager.Sfx.Over);
            GameManager.instance.diePanel.SetActive(true);
        }
    }
    IEnumerator Clear()
    {   
        yield return new WaitForSeconds(clearCount);
        GameManager.instance.SfxPlayer(GameManager.Sfx.Clear);
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
            StartCoroutine(Die());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            isClear = true;
            if (!win)
            {
                win = true;
                anim.SetTrigger("Win");
            }
            StartCoroutine(Clear());
        }

        else if(collision.gameObject.CompareTag("Transform"))
        {
            istransform = true;
            anim.SetBool("isWalk", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            anim.SetBool("isDown", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            isGround = false;
        }
    }
}
