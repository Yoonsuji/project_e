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
    private Image imgButton;
    void Start()
    {
        imgButton = GetComponent<Image>();
        imgButton.alphaHitTestMinimumThreshold = 0.1f;
    }
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
            imgButton.rectTransform.sizeDelta = new Vector2(135, 37);
            transform.Rotate(new Vector3(0, 0, 10));
            elapsedTime += Time.deltaTime * moveSpeed;

            yield return null;
        }

        transform.position = targetTransform.position;
        transform.rotation = Quaternion.Euler(0, 0, -24);
        isMoving = false;

        button2.interactable = true;
        imgButton.raycastTarget = !imgButton.raycastTarget;
    }
}
