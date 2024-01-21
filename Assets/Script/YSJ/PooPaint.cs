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
        // �ʱ⿡ �̹����� ����
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }

    // SetVisibility �޼��� �߰�
    public void SetVisibility(bool isVisible)
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
            Debug.Log("Coroutine stopped");
        }

        if (isVisible)
        {
            // �̹����� ��Ÿ������ ���̵��� ����
            fadeCoroutine = StartCoroutine(FadeIn());
        }
        else
        {
            // �̹����� ��������� ���̵�ƿ� ����
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
