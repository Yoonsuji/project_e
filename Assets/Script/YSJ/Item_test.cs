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
    private Image imgButton;
    public GameObject HideItem1;
    

    void Start()
    {
        imgButton = GetComponent<Image>();
        imgButton.alphaHitTestMinimumThreshold = 0.1f;
    }
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

        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(startingPos, targetTransform.position, elapsedTime);
            transform.Rotate(new Vector3(0, 0, 10));
            imgButton.rectTransform.sizeDelta = new Vector2(62, 104);
            elapsedTime += Time.deltaTime * moveSpeed;
            //HideItem1.SetActive(false);

            yield return null;
        }

        transform.position = targetTransform.position;
        transform.rotation = Quaternion.Euler(0, 0, -24);
        isMoving = false;

        button1.interactable = true;
        imgButton.raycastTarget = !imgButton.raycastTarget;
    }
}
