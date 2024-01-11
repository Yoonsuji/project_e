using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    //public bool die;
    //public GameObject ghost;
    //Animator anim;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie) StartCoroutine(Die());
        Move();
    }

    private void Move()
    {
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (!isDie) rigid.velocity = new Vector2(speed, 0);
    }
    /*
    private IEnumerator Die()
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
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D (collision);
        if (collision.gameObject.CompareTag("Wall"))
        {
            speed = -speed;
            renderer.flipX = renderer.flipX ? false : true;
        }
    }
}
