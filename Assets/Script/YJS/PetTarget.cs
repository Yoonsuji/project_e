using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetTarget : MonoBehaviour
{
    public float minX = -300f;
    public float maxX = 300f;
    public float minY = -580f;
    public float maxY = 580f;
    public CapybaraCurrentItem capybaraCurrentItem;
    private void Start()
    {
        if (capybaraCurrentItem.currentBack != null)
        {
            if (capybaraCurrentItem.currentBack.name == "HotSpring")
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void ChangeTransform()
    {
        // 무작위 위치 생성
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // 현재 RectTransform의 position 값 가져오기
        Vector3 currentPosition = this.GetComponent<RectTransform>().anchoredPosition;

        // 새로운 위치 설정
        currentPosition.x = randomX;
        currentPosition.y = randomY;

        // RectTransform의 position 값 적용
        this.GetComponent<RectTransform>().anchoredPosition = currentPosition;
    }
}
