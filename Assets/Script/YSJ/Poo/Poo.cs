using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poo : MonoBehaviour
{
    public float fallSpeed = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            HeartSystem.hp -= 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        if(transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
}
