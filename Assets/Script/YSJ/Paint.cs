using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paint : MonoBehaviour
{
    public float fadeDuration;
    public float showDuration;
    public float AttackMin = 1f;
    public float AttackMax = 3f;
    public Image image;
    private Coroutine fadeCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        StartCoroutine(AttackWithRandom());
    }

    IEnumerator AttackWithRandom()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(AttackMin, AttackMax));
            Attack();
        }
        
    }

    // Update is called once per frame
    private void Attack()
    {
        if(fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeInAndOutImage());
    }

    private IEnumerator FadeInAndOutImage()
    {
        yield return StartCoroutine(FadeIn());
        yield return new WaitForSeconds(showDuration);  
        yield return StartCoroutine(FadeOut());
        fadeCoroutine = null;
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while(elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
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
    }
}
