using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public GoodsPrefab goodsPrefab;
    private CoinManager coinTextManager;
    public AudioClip audioClip;
    private AudioSource audioSource;
    public float fallSpeed = 5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coinTextManager = FindObjectOfType<CoinManager>();
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

    void Next()
    {
        coinTextManager.UpdateCoinText(1);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
}