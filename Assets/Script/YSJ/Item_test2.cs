using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item_test2 : MonoBehaviour, IPointerClickHandler
{
    public Transform targetTransform;
    public float moveSpeed = 2.0f;
    public bool isMoving = false;
    public Button button1;
    public Button button2;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        if(isMoving)
            yield break;
        
        isMoving = true;

        float elapsedTime = 0f;
        Vector3 startingPos = transform.position;

        while (elapsedTime<1f)
        {
            transform.position = Vector3.Lerp(startingPos, targetTransform.position, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;

            yield return null;
        }

        transform.position = targetTransform.position;
        isMoving = false;

        button2.interactable = true;
    }
}