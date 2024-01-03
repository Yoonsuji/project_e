using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBox : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public Sprite DragEffact;
    private float spacing = 1f;
    private PlayerMove player;
    private Vector3 initialPosition;

    void Start()
    {
        foreach (GameObject enemyPrefab in enemyPrefabs)
        {
            GameObject spawnedEnemy = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
            spawnedEnemy.transform.parent = transform;
            spawnedEnemy.transform.Translate(new Vector3(spacing, 0f, 0f));
            spacing += -1f;
        }
        player = FindObjectOfType<PlayerMove>();
        if (player == null)
        {
            print("�÷��̾ ����");
        }
    }
    private void OnMouseEnter()
    {
        // ���콺�� ������Ʈ ���� �ö���� �� ����Ǵ� �κ�
        Debug.Log("���콺�� ������Ʈ ���� �ö�Խ��ϴ�!");
    }

    private void OnMouseExit()
    {
        // ���콺�� ������Ʈ���� ����� �� ����Ǵ� �κ�
        Debug.Log("���콺�� ������Ʈ���� ������ϴ�!");
    }
}