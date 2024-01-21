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
    public GameObject PooPaint;
    public CanvasGroup pooPaintCanvasGroup;
    public float fadeInDuration = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        PooPaint.SetActive(false);
        pooPaintCanvasGroup = PooPaint.GetComponent<CanvasGroup>();
        if (pooPaintCanvasGroup == null)
        {
            pooPaintCanvasGroup = PooPaint.AddComponent<CanvasGroup>();
        }
        StartCoroutine(FadeInPooPaint());

    }

    IEnumerator FadeInPooPaint()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeInDuration)
        {
            pooPaintCanvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        StartCoroutine(FadeOutPooPaint());
    }

    IEnumerator FadeOutPooPaint()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeInDuration)
        {
            pooPaintCanvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeInDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        PooPaint.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Poo"))
        {
            PooPaint.SetActive(true);
            pooPaintCanvasGroup.alpha = 0f;
            StartCoroutine(FadeInPooPaint());
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
