using System.Collections;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Transform HandTarget;
    public Transform HandTarget2;
    public float Speed = 1.0f;
    public bool isMoving = false;
    private Coroutine currentBehavior;


    void Update()
    {
        if (!isMoving && currentBehavior == null)
        {
            StartHandMove();
        }
    }

    public void StartHandMove()
    {
        if (currentBehavior != null)
        {
            StopCoroutine(currentBehavior);
            gameObject.SetActive(false);
        }
        currentBehavior = StartCoroutine(HandMove());
    }

    IEnumerator HandMove()
    {
        isMoving = true;
        float elapsedTime = 0f;
        Vector3 startingPos = transform.position;

        while (elapsedTime < 1f)
        {
            transform.position = Vector3.LerpUnclamped(startingPos, HandTarget2.position, elapsedTime);
            elapsedTime += Time.deltaTime * Speed;

            yield return null;
        }

        Vector3 temp = HandTarget.position;
        HandTarget.position = HandTarget2.position;
        HandTarget2.position = temp;

        isMoving = false;
        currentBehavior = null;
    }
}
