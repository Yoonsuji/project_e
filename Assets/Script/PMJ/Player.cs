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
    public float clearCount;
    public float rayDistance;

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
        //Move();
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
        anim.SetBool("isWalk", true);
        if (!isDie) rigid.velocity = new Vector2(speed, 0);
    }
    IEnumerator Clear()
    {
        yield return new WaitForSeconds(clearCount);
        GameManager.instance.clearPanel.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            speed = -speed;
            renderer.flipX = renderer.flipX ? false : true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            StartCoroutine(Clear());
        }
    }
}
