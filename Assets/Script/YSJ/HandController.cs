using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HandController : MonoBehaviour
{
    public Transform HandTarget;
    public Transform HandTarget2;
    public float Speed = 1.0f;
    public bool isMoving = false;

    private Coroutine currentBehavior;
    void Update()
    {
        if (!isMoving) 
        {
            StartCoroutine(Move());
        }
    }
    public void StartHandMove()
    {
        if (currentBehavior != null)
        {
            StopCoroutine(currentBehavior);
        }
        currentBehavior = StartCoroutine(HandMove());
    }


    public IEnumerator Move()
    {
        isMoving = true;
        float elapsedTime = 0f;
        Vector3 startingPos = transform.position;

        while(elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(startingPos, HandTarget.position, elapsedTime);
            elapsedTime += Time.deltaTime * Speed;

            yield return null;
        }
        isMoving = false;
    }

    IEnumerator HandMove()
    {
        float elapsedTime = 0f;
        Vector3 startingPos = transform.position;
        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(startingPos, HandTarget2.position, elapsedTime);
            elapsedTime += Time.deltaTime * Speed;

            yield return null;
        }
        currentBehavior = null;
    }
}
