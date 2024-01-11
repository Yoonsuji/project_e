using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class CorrectButton : MonoBehaviour
{
    public GameObject Background;
    public float Distance = 1.0f;
    public float speed = 3.0f;
    public float HandMoveSpeed = 1.0f;
    public float smoothTime = 0.5f;
    public GameObject Check;
    public GameObject Hand;
    public Slider timeSlider;
    public Transform HandTransform;
    public HandController handController;

    // Start is called before the first frame update
    void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(CorrectClick);
        }
    }
    public void CorrectClick()
    {
        Check.SetActive(true);
        if (Background != null)
        {
            StartCoroutine(MoveBackground());

            Button button = GetComponent<Button>();

            if (button != null)
            {
                button.onClick.RemoveAllListeners();
            }

        }
        if (handController != null)
        {
            handController.StartHandMove();
        }

    }
    IEnumerator MoveBackground()
    {

        Vector3 startPosition = Background.transform.position;
        Vector3 targetPosition = startPosition + Vector3.left * Distance;

        float elapsedTime = 0f;
        float duration = Distance / speed;

        while (elapsedTime < duration)
        {
            Background.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Background.transform.position = targetPosition;
    }
}
