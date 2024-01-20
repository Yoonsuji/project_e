using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetTarget : MonoBehaviour
{
    public float minX = -300f;
    public float maxX = 300f;
    public float minY = -580f;
    public float maxY = 580f;
    public void ChangeTransform()
    {
        // ������ ��ġ ����
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // ���� RectTransform�� position �� ��������
        Vector3 currentPosition = this.GetComponent<RectTransform>().anchoredPosition;

        // ���ο� ��ġ ����
        currentPosition.x = randomX;
        currentPosition.y = randomY;

        // RectTransform�� position �� ����
        this.GetComponent<RectTransform>().anchoredPosition = currentPosition;
    }
}
