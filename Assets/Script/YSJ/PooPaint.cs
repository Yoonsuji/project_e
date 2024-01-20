using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PooPaint : MonoBehaviour
{
    public float fadeDuration;
    public Image image;
    private Coroutine fadeCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        // 초기에 이미지를 숨김
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }

    // SetVisibility 메서드 추가
    public void SetVisibility(bool isVisible)
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
            Debug.Log("Coroutine stopped");
        }

        if (isVisible)
        {
            // 이미지가 나타나도록 페이드인 실행
            fadeCoroutine = StartCoroutine(FadeIn());
        }
        else
        {
            // 이미지가 사라지도록 페이드아웃 실행
            fadeCoroutine = StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
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
