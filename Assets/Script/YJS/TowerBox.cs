using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBox : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    public GameObject EnemySample;
    public Sprite enemySprite_1;
    public Sprite enemySprite_2;
    public PlayerScript player;
    public int enemyCount;
    public bool isSpawnPoint;
    private Vector3 initialPosition;
    private Renderer objectRenderer;
    private Color originalColor;
    private int lineSize, rowSize;
    private float spacing = 0.9f;
    string[,] dataTable;

    void Start()
    {
        player = PlayerScript.FindObjectOfType<PlayerScript>();
        if (isSpawnPoint == true)
        {
            player.nowBox = this;
            player.Move(this);
            new WaitForSeconds(0.1f);
            player.canMove = false;
        }
    }
    private void Update()
    {
        for(int i = 0; i < EnemyList.Count; i++)
        {
            if (EnemyList[i] == null)
            {
                EnemyList.Remove(EnemyList[i]);
                enemyCount--;
            }
        }
    }
    public void SpawnEnemy(int enemyType, int enemyPower)
    {
        GameObject spawnedEnemy = Instantiate(EnemySample, this.transform.position, Quaternion.identity);
        if (enemyType == 0)
        {
            spawnedEnemy.GetComponent<EnemyPower>().SpriteChange(enemySprite_1);
        }
        else if (enemyType == 1)
        {
            spawnedEnemy.GetComponent<EnemyPower>().SpriteChange(enemySprite_2);
        }
        spawnedEnemy.GetComponent<EnemyPower>().enemyPower = enemyPower;
        spawnedEnemy.transform.parent = transform;
        spawnedEnemy.transform.Translate(new Vector3(spacing, 0f, 0f));
        EnemyList.Add(spawnedEnemy);
        enemyCount++;
        spacing += -0.5f;
    }
    private void OnMouseEnter()
    {
        //마우스올림
    }

    private void OnMouseExit()
    {
        //마우스벗어남
    }

    public void Attacked()
    {
        if (enemyCount > 0)
        {
            if (player.playerPower <= EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower)
            {
                player.PlayerDie();
                print("실패!!");
            }
            else
            {
                int i = EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower;
                EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower -= player.playerPower;
                player.playerPower += i;
            }
        }

    }

    private void OnMouseDown()
    {
        player.Move(this);
    }
}