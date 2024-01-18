using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectButton : MonoBehaviour
{
    public GameObject Background;
    public float Distance = 1.0f;
    public float speed = 3.0f;
    public float HandMoveSpeed = 1.0f;
    public float smoothTime = 0.5f;
    public GameObject Check;
    public Button button2;
    
    

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
        button2.interactable = false;
        if (Background != null)
        {
            StartCoroutine(MoveBackground());

            Button button = GetComponent<Button>();

            if (button != null)
            {
                button.onClick.RemoveAllListeners();
            }

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