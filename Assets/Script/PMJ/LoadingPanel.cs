using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingPanel : MonoBehaviour
{
    public SceneChange sceneChange;
    public float moveDistance = 200f; // 이동 거리
    public float moveDuration = 1.5f; // 이동 시간

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
        // 이미 인스턴스가 있다면 이 인스턴스를 파괴
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        // 씬이 변경되더라도 이 객체를 파괴하지 않음
        DontDestroyOnLoad(this.gameObject);

        _instance = this;
    }
    IEnumerator MovePanel()
    {
        while (true)
        {
            // 아래로 이동
            yield return MoveY(rectTransform.anchoredPosition.y - moveDistance, moveDuration);

            // 대기 시간
            //SceneManager.LoadScene(sceneChange.gameNumber);
            yield return new WaitForSeconds(0.7f);

            // 위로 이동
            yield return MoveY(rectTransform.anchoredPosition.y + moveDistance, moveDuration);

            // 대기 시간
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
