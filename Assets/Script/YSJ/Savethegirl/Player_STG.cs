using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Player_STG : MonoBehaviour
{
    public Animator animator;
    public float fadeDuration;
    public Image image;
    public float moveSpeed = 1.0f;
    public float lerpTime = 0.5f;

    public Button button1;
    public Button button2;
    public Transform PlayerTarget;
    public Canvas ClearCanvas;
    public Canvas GameCanvas;
    public GameObject TimeNo;
    public GameObject Paint;
    public GameObject Choco;
    public GameObject Item1;
    public GameObject Item2;

    private bool isCleaning = false;

    void Start()
    {
        button1.onClick.AddListener(OnButtonClick);
        button2.onClick.AddListener(OnButtonClick2);
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall");
            ClearCanvas.gameObject.SetActive(true);
            GameCanvas.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("TimeNo"))
        {
            Debug.Log("TimeNo");
            TimeNo.gameObject.SetActive(false);
            Paint.gameObject.SetActive(false);
            //Item1.gameObject.SetActive(false);
            //animator.SetTrigger("isClean");
        }
        if (collision.gameObject.CompareTag("ChocoClean"))
        {
            Debug.Log("Clean");

            animator.SetTrigger("isClean");
            if (!isCleaning)
            {
                StartCoroutine(CleanAnimation());
            }
            //Choco.gameObject.SetActive(false);
        }
    }

    private IEnumerator CleanAnimation()
    {
        isCleaning = true;
        animator.SetBool("isCleaning", true);

        // Add a delay of 2 seconds for the clean animation
        yield return new WaitForSeconds(0.5f);

        // Complete the clean animation
        animator.SetBool("isCleaning", false);

        // Pause the player for a short duration (adjust as needed)
        float pauseDuration = 0.5f;
        yield return new WaitForSeconds(pauseDuration);

        // Start fading out after the clean animation and pause
        StartCoroutine(FadeOut());

        isCleaning = false;
    }

    void OnButtonClick()
    {
        StartCoroutine(Move());
    }
    void OnButtonClick2()
    {
        animator.SetTrigger("isDie");
        Invoke("gameObjectDelect", 1.1f);
    }
    void gameObjectDelect()
    {
        gameObject.SetActive(false);
        Item2.SetActive(false);
    }
    private IEnumerator Move()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("isWalk", true);
        Item1.gameObject.SetActive(false);
        while (Vector2.Distance(transform.position, PlayerTarget.position) > 0.1f)
        {
            transform.position = Vector2.Lerp(transform.position, PlayerTarget.position, lerpTime * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        Choco.gameObject.SetActive(false);
    }
}

