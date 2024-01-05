using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class Item_test : MonoBehaviour, IPointerClickHandler
{
    public static Item_test Instance;
    public Transform targetTransform;
    public float moveSpeed = 2.0f;
    public bool isMoving = false;
    public Button button1;
    public Button button2;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(MoveToTarget());
    }

    public IEnumerator MoveToTarget()
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

        button1.interactable = true;
    }
}
