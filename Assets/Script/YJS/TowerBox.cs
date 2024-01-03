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
            print("플레이어가 없음");
        }
    }
    private void OnMouseEnter()
    {
        // 마우스가 오브젝트 위에 올라왔을 때 실행되는 부분
        Debug.Log("마우스가 오브젝트 위에 올라왔습니다!");
    }

    private void OnMouseExit()
    {
        // 마우스가 오브젝트에서 벗어났을 때 실행되는 부분
        Debug.Log("마우스가 오브젝트에서 벗어났습니다!");
    }
}