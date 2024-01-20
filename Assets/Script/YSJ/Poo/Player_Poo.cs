using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Poo : MonoBehaviour
{
    Animator animator;
    public bool LeftMove = false;
    public bool RightMove = false;
    public GoodsPrefab goodsPrefab;
    public TextMeshProUGUI CoinText;
    Vector3 moveVelocity = Vector3.zero;
    private SpriteRenderer playerSpriteRenderer;
    public float moveSpeed = 10;
    public AudioClip audioClip;
    private AudioSource audioSource;
    public PooPaint pooPaint;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;

    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Poo"))
        {
            PooPaint pooPaint = other.GetComponent<PooPaint>();
            if (pooPaint != null)
            {
                pooPaint.SetVisibility(true);
                Debug.Log("paint");
            }
        }
    }
    void FixedUpdate()
    {
        if (LeftMove)
        {
            animator.SetBool("isWalk", true);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            playerSpriteRenderer.flipX = true;
            moveVelocity = new Vector3(-0.10f, 0, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;

        }
        if(RightMove)
        {
            
            animator.SetBool("isWalk", true);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            playerSpriteRenderer.flipX = false;
            moveVelocity = new Vector3(+0.10f, 0, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;

        }
    }
    
}
