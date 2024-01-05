using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBox : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    public GameObject EnemySample;
    public CameraMove cameraMove;
    public List<Sprite> nolmalEnemySprite = new List<Sprite>();
    public List<Sprite> multiplicationEnemyEnemySprite = new List<Sprite>();
    public List<Sprite> BossEnemySprite = new List<Sprite>();
    public PlayerScript player;
    public int enemyCount;
    public bool isSpawnPoint;
    private Vector3 initialPosition;
    public int towerNumber;
    private Renderer objectRenderer;
    private Color originalColor;
    private int lineSize, rowSize;
    private float spacing = 0.9f;
    private TowerManager towerManager;
    private Camera mainCamera;
    string[,] dataTable;

    void Start()
    {
        mainCamera = Camera.main;
        cameraMove = FindObjectOfType<CameraMove>();
        towerManager = FindObjectOfType<TowerManager>();
        player = PlayerScript.FindObjectOfType<PlayerScript>();
        if (isSpawnPoint == true)
        {
            player.nowBox = this;
            player.Move(this);
            new WaitForSeconds(0.1f);
        }
    }
    private void Update()
    {
        Vector3 objectPosition = transform.position;
        Vector3 cameraViewPos = mainCamera.WorldToViewportPoint(objectPosition);

        if (cameraViewPos.x < 0 && cameraMove.isActive == false)
        {
            Destroy(this.gameObject);
        }
        for (int i = 0; i < EnemyList.Count; i++)
        {
            if (EnemyList[i] == null)
            {
                EnemyList.Remove(EnemyList[i]);
                enemyCount--;
                towerManager.enemyCountList[towerNumber]--;
                towerManager.EnemyCheck();
            }
        }
    }
    public void SpawnEnemy(float enemyType, int enemyPower)
    {
        GameObject spawnedEnemy = Instantiate(EnemySample, this.transform.position, Quaternion.identity);
        if (Mathf.Approximately(enemyType, Mathf.Floor(enemyType)))
        {
            if (enemyType != 0f)
            {
                spawnedEnemy.GetComponent<EnemyPower>().selectedType = EnemyPower.enemyType.nolmalEnemy;
                spawnedEnemy.GetComponent<EnemyPower>().SpriteChange(nolmalEnemySprite[(int)enemyType-1]);
            }
            else
            {
                spawnedEnemy.GetComponent<EnemyPower>().selectedType = EnemyPower.enemyType.BossEnemy;
                spawnedEnemy.GetComponent<EnemyPower>().SpriteChange(BossEnemySprite[0]);
            }
        }
        else
        {
            if (Mathf.FloorToInt(enemyType) == 0)//°ö
            {
                spawnedEnemy.GetComponent<EnemyPower>().selectedType = EnemyPower.enemyType.multiplicationEnemy;
                spawnedEnemy.GetComponent<EnemyPower>().SpriteChange(multiplicationEnemyEnemySprite[0]);
            }
            else if(Mathf.FloorToInt(enemyType) == 1)//Á¦°ö
            {
                spawnedEnemy.GetComponent<EnemyPower>().selectedType = EnemyPower.enemyType.squareEnemy;
                spawnedEnemy.GetComponent<EnemyPower>().SpriteChange(multiplicationEnemyEnemySprite[1]);
            }
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
        //¸¶¿ì½º¿Ã¸²
    }

    private void OnMouseExit()
    {
        //¸¶¿ì½º¹þ¾î³²
    }

    public void Attacked()
    {
        if (enemyCount > 0)
        {
            if(EnemyList[enemyCount - 1].GetComponent<EnemyPower>().selectedType == EnemyPower.enemyType.nolmalEnemy)
            {
                if (player.playerPower <= EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower)
                {
                    player.PlayerDie();
                }
                else
                {
                    int i = EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower;
                    EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower -= player.playerPower;
                    if (EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower < 0)
                    {
                        EnemyList[enemyCount - 1].GetComponent<EnemyPower>().EnemyDie();
                    }
                    player.playerPower += i;
                    if (player.playerPower <= 0)
                    {
                        player.PlayerDie();
                    }
                }
            }
            else if(EnemyList[enemyCount - 1].GetComponent<EnemyPower>().selectedType == EnemyPower.enemyType.multiplicationEnemy)
            {
                player.playerPower = player.playerPower * EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower;
                EnemyList[enemyCount - 1].GetComponent<EnemyPower>().EnemyDie();
            }
            else if (EnemyList[enemyCount - 1].GetComponent<EnemyPower>().selectedType == EnemyPower.enemyType.squareEnemy)
            {
                int originalPower = player.playerPower;
                for(int i=0;i< EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower - 1; i++)
                {
                    player.playerPower = player.playerPower * originalPower;
                }
                EnemyList[enemyCount - 1].GetComponent<EnemyPower>().EnemyDie();
            }
        }

    }

    private void OnMouseDown()
    {
        player.Move(this);
    }
}