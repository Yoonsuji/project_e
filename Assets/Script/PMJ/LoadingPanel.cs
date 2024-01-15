using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingPanel : MonoBehaviour
{
    public SceneChange sceneChange;
    public float moveDistance = 200f; // �̵� �Ÿ�
    public float moveDuration = 1.5f; // �̵� �ð�

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(MovePanel());
    }
    private static LoadingPanel _instance;
    public static LoadingPanel Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("LoadingPanel");
                _instance = obj.AddComponent<LoadingPanel>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // �̹� �ν��Ͻ��� �ִٸ� �� �ν��Ͻ��� �ı�
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        // ���� ����Ǵ��� �� ��ü�� �ı����� ����
        DontDestroyOnLoad(this.gameObject);

        _instance = this;
    }
    IEnumerator MovePanel()
    {
        while (true)
        {
            // �Ʒ��� �̵�
            yield return MoveY(rectTransform.anchoredPosition.y - moveDistance, moveDuration);

            // ��� �ð�
            //SceneManager.LoadScene(sceneChange.gameNumber);
            yield return new WaitForSeconds(0.7f);

            // ���� �̵�
            yield return MoveY(rectTransform.anchoredPosition.y + moveDistance, moveDuration);

            // ��� �ð�
            //gameObject.SetActive(false);
        }
    }

    IEnumerator MoveY(float targetY, float duration)
    {
        float elapsed = 0f;
        Vector2 initialPosition = rectTransform.anchoredPosition;
        Vector2 targetPosition = new Vector2(rectTransform.anchoredPosition.x, targetY);

        while (elapsed < duration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;
    }
}
