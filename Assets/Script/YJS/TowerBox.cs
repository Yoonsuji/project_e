using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBox : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    private float spacing = 1f;
    public PlayerMove player;
    private Vector3 initialPosition;
    private Renderer objectRenderer;
    private Color originalColor;
    private int lineSize, rowSize;
    string[,] dataTable;

    void Start()
    {
        player = PlayerMove.FindObjectOfType<PlayerMove>();
        foreach (GameObject enemyPrefab in enemyPrefabs)
        {
            GameObject spawnedEnemy = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
            spawnedEnemy.transform.parent = transform;
            spawnedEnemy.transform.Translate(new Vector3(spacing, 0f, 0f));
            spacing += -1f;
        }
    }
    private void OnMouseEnter()
    {
        //마우스올림
    }

    private void OnMouseExit()
    {
        //마우스벗어남
    }
    private void OnMouseDown()
    {
        player.GetComponent<PlayerMove>().nowBox = this.gameObject;
        player.Move();
    }
}