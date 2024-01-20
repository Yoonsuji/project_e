using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poo : MonoBehaviour
{
    public float fallSpeed = 5f;
    public float fallAcceleration = 0.1f;
    public AudioClip audioClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            Invoke("Next", 0.2f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        fallSpeed += fallAcceleration * Time.deltaTime;
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
        if(transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
    void Next()
    {
        HeartSystem.hp -= 1;
        Destroy(this.gameObject);
    }

}
