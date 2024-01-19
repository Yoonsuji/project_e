using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PooPaint : MonoBehaviour
{
    public float fadeDuration;
    public float showDuration;
    public Image image;
    private Coroutine fadeCoroutine;
    private int activeHearts;

    // Start is called before the first frame update
    void Start()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        StartCoroutine(AttackWithCheck());
    }

    IEnumerator AttackWithCheck()
    {
        while (true)
        {
            yield return null;
        }
    }

    public void Attack()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeInAndOutImage());
    }

    public IEnumerator FadeInAndOutImage()
    {
        yield return StartCoroutine(FadeIn());
        yield return new WaitForSeconds(showDuration);
        yield return StartCoroutine(FadeOut());
        fadeCoroutine = null;
    }

    public IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }

    public IEnumerator FadeOut()
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
