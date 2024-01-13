using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBox : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    public GameObject EnemySample;
    public Sprite topBoxSprite;
    public CameraMove cameraMove;
    public List<Sprite> nolmalEnemySprite = new List<Sprite>();
    public List<Sprite> multiplicationEnemyEnemySprite = new List<Sprite>();
    public List<Sprite> BossEnemySprite = new List<Sprite>();
    public List<Sprite> ItemSprite = new List<Sprite>();
    public PlayerScript player;
    public int enemyCount;
    public bool isSpawnPoint;
    public GameObject BackObject;
    private Vector3 initialPosition;
    public int towerNumber;
    private Renderer objectRenderer;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private int lineSize, rowSize;
    private float spacing = 0.8f;
    private TowerManager towerManager;
    private Camera mainCamera;
    public bool isTopBox = false;
    public bool isBossBox = false;
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
        if (isBossBox == true)
        {
            Renderer renderer = BackObject.GetComponent<Renderer>();
            foreach (Material material in renderer.materials)
            {
                Color color = material.color;
                color.a = 0f;
                material.color = color;
            }
        }
        else
        {
            if (isTopBox == true)
            {
                BackObject.GetComponent<SpriteRenderer>().sprite = topBoxSprite;
                BackObject.transform.Translate(new Vector3(0f, 0.348f, 0f));
            }
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
    public void isBossTurn()
    {
        player.nowBox = this;
        player.BossTurnMove();
    }
    public void SpawnEnemy(float enemyType, int enemyPower)
    {
        GameObject spawnedEnemy = Instantiate(EnemySample, this.transform.position, Quaternion.identity);
        if (Mathf.Approximately(enemyType, Mathf.Floor(enemyType)))
        {
            if (enemyType > 0f)
            {
                TypeSelect(spawnedEnemy, EnemyPower.enemyType.nolmalEnemy);
            }
            else if (enemyType < 0f)
            {
                TypeSelect(spawnedEnemy, EnemyPower.enemyType.item);
            }
            else
            {
                TypeSelect(spawnedEnemy, EnemyPower.enemyType.BossEnemy);
            }
        }
        else
        {
            if (Mathf.FloorToInt(enemyType) == 0)//곱
            {
                TypeSelect(spawnedEnemy, EnemyPower.enemyType.multiplicationEnemy);
            }
            else if(Mathf.FloorToInt(enemyType) == 1)//제곱
            {
                TypeSelect(spawnedEnemy, EnemyPower.enemyType.squareEnemy);
            }
        }
        spawnedEnemy.GetComponent<EnemyPower>().enemyPower = enemyPower;
        spawnedEnemy.transform.parent = transform;
        spawnedEnemy.transform.Translate(new Vector3(spacing, -0.2f, 0f));
        EnemyList.Add(spawnedEnemy);
        enemyCount++;
        spacing += -0.5f;
    }
    private void TypeSelect(GameObject spawnedEnemy, EnemyPower.enemyType type)
    {
        spawnedEnemy.GetComponent<EnemyPower>().selectedType = type;
    }
    public void LastBossAttack()
    {
        if (EnemyList[0].GetComponent<EnemyPower>().enemyPower >= player.playerPower)
        {
            print("보스가 이김");
            player.PlayerDie();
        }
        else
        {
            print("플레이어가 이김");
            towerManager.Win();
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

    public void Attacked()
    {
        if (enemyCount > 0)
        {
            
            if(EnemyList[enemyCount - 1].GetComponent<EnemyPower>().selectedType == EnemyPower.enemyType.item)
            {
                player.playerPower += EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower;
                EnemyDieLoad();
                player.GetComponent<Animator>().SetBool("Drive", false);
                if (player.playerPower <= 0)
                {
                    player.PlayerDie();
                }
            }
            else if(EnemyList[enemyCount - 1].GetComponent<EnemyPower>().selectedType == EnemyPower.enemyType.BossEnemy)
            {
                if (player.playerPower <= EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower)
                {
                    player.playerPower = 0;
                    player.PlayerDie();
                }
                else
                {
                    player.playerPower += EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower;
                    EnemyDieLoad();
                }
            }
            else
            {
                EnemyList[enemyCount - 1].GetComponent<EnemyPower>().ChangeAttackAnime();
                player.canMove = false;
                Invoke("AnimeLoad", 3f);
            }
        }
    }
    private void AnimeLoad()
    {
        player.canMove = true;
        if (EnemyList[enemyCount - 1].GetComponent<EnemyPower>().selectedType == EnemyPower.enemyType.nolmalEnemy)
        {
            if (player.playerPower <= EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower)
            {
                player.playerPower = 0;
                player.PlayerDie();
            }
            else
            {
                player.playerPower += EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower;
                EnemyDieLoad();
            }
        }
        else if (EnemyList[enemyCount - 1].GetComponent<EnemyPower>().selectedType == EnemyPower.enemyType.multiplicationEnemy)
        {
            player.playerPower = player.playerPower * EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower;
            EnemyDieLoad();
        }
        else if (EnemyList[enemyCount - 1].GetComponent<EnemyPower>().selectedType == EnemyPower.enemyType.squareEnemy)
        {
            int originalPower = player.playerPower;
            for (int i = 0; i < EnemyList[enemyCount - 1].GetComponent<EnemyPower>().enemyPower - 1; i++)
            {
                player.playerPower = player.playerPower * originalPower;
            }
            EnemyDieLoad();
        }

    }
    private void EnemyDieLoad()
    {
        EnemyList[enemyCount - 1].GetComponent<EnemyPower>().EnemyDie();
    }

    private void OnMouseDown()
    {
        //타워터치
        if (MenuStatic.isMenuOpen == false)
        {
            if (player.canMove == true)
            {
                player.Move(this);
            }
        }
    }
}