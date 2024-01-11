using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Metaball_liquid") || collision.gameObject.CompareTag("Metaball_liquid2"))
        {
            //water = GameObject.FindGameObjectsWithTag("Metaball_liquid");
            //GameManager.instance.StartCoroutine(Fadeout(gameObject, collision));
            //GameManager.instance.FadeOut(gameObject, collision);
            string collisionTag = collision.gameObject.tag;
            GameManager.instance.StartCoroutine(GameManager.instance.FadeOut(gameObject, collisionTag));
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Metaball_liquid") || collision.gameObject.CompareTag("Metaball_liquid2"))
        {
            //water = GameObject.FindGameObjectsWithTag("Metaball_liquid");
            //GameManager.instance.StartCoroutine(Fadeout(gameObject, collision));
            //GameManager.instance.FadeOut(gameObject, collision);
            string collisionTag = collision.gameObject.tag;
            GameManager.instance.StartCoroutine(GameManager.instance.FadeOut(gameObject, collisionTag));
            gameObject.SetActive(false);
        }

    }
}
