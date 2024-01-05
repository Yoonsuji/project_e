using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBox : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    public GameObject EnemySample;
    public CameraMove cameraMove;
    public List<Sprite> enemySprite = new List<Sprite>();
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
    public void SpawnEnemy(int enemyType, int enemyPower)
    {
        GameObject spawnedEnemy = Instantiate(EnemySample, this.transform.position, Quaternion.identity);
        if (enemyType > 0)
        {
            spawnedEnemy.GetComponent<EnemyPower>().SpriteChange(enemySprite[enemyType-1]);
        }
        spawnedEnemy.GetComponent<EnemyPower>().enemyType = enemyType;
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
                if (EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower < 0)
                {
                    EnemyList[enemyCount - 1].GetComponent<EnemyPower>().EnemyDie();
                }
                player.playerPower += i;
            }
        }

    }

    private void OnMouseDown()
    {
        player.Move(this);
    }
}