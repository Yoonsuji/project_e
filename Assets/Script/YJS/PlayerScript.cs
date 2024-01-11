using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    Vector3 mousePosition;
    private Vector3 initialPosition;
    public TowerBox nowBox;
    public GameObject MoveBoom;
    public List<RuntimeAnimatorController> capibaraAnime = new List<RuntimeAnimatorController>();
    public CameraMove cameraMove;
    public int playerPower;
    public TMP_Text powerText;
    public bool canMove;
    public GameObject DiePanel;
    private TowerBox exBox;
    private GameObject exBoom;
    private TowerBox previousBox = null;
    private Color originalTextColor;

    private void Start()
    {
        originalTextColor = powerText.color;
        this.GetComponent<Animator>().runtimeAnimatorController = capibaraAnime[0];
        canMove = true;
    }

    public void Move(TowerBox towerBox)
    {
        if (cameraMove.isFirst != true)
        {
            if (previousBox == towerBox)
            {
                if (towerBox.enemyCount != 0)
                {
                    TransPotion(towerBox.EnemyList[towerBox.enemyCount - 1].gameObject);
                }
            }
            else
            {
                this.GetComponent<Animator>().runtimeAnimatorController = null;
                Color currentColor = powerText.color;
                currentColor.a = 0f;
                powerText.color = currentColor;
                GameObject spawnedBoom = Instantiate(MoveBoom, this.transform.position, Quaternion.identity);
                spawnedBoom.transform.position = this.transform.position;
                spawnedBoom.transform.position = nowBox.transform.position + Vector3.down * 0.25f;
                exBox = towerBox;
                exBoom = spawnedBoom;
                Invoke("Boom", 0.5f);
                Invoke("DoMove", 2f);
            }
        }
        else
        {
            exBox = towerBox;
            DoMove();
        }
    }
    void TransPotion(GameObject target)
    {
        // 현재 위치에서 목표 위치까지 부드럽게 이동
        StartCoroutine(MoveObject(target.transform.position.x));
    }
    System.Collections.IEnumerator MoveObject(float targetX)
    {
        float elapsedTime = 0f;
        float startingX = transform.position.x;
        targetX -= 0.5f;

        while (elapsedTime < 1f)
        {
            float newX = Mathf.Lerp(startingX, targetX, elapsedTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            elapsedTime += Time.deltaTime * 0.6f;
            yield return null;
        }
        nowBox.Attacked();
    }

    private void Boom()
    {
        Destroy(exBoom.gameObject);
    }

    public void DoMove()
    {
        this.GetComponent<Animator>().runtimeAnimatorController = capibaraAnime[0];
        powerText.color = originalTextColor;
        if (canMove == true)
        {
            nowBox = exBox;

            this.transform.position = nowBox.transform.position;
            if (nowBox.enemyCount != 0)
            {
                this.transform.position = new Vector3(nowBox.EnemyList[nowBox.enemyCount - 1].transform.position.x - 0.6f, this.transform.position.y, this.transform.position.z);
            }
            if (cameraMove.isFirst != true)
            {
                GameObject spawnedBoom = Instantiate(MoveBoom, this.transform.position, Quaternion.identity);
                spawnedBoom.transform.position = this.transform.position;
                spawnedBoom.transform.position = nowBox.transform.position + Vector3.down * 0.25f;
                exBoom = spawnedBoom;
                Invoke("Boom", 0.5f);
            }
            previousBox = nowBox;
            nowBox.Attacked();
        }
    }
    private void Update()
    {
        powerText.text = playerPower.ToString();
    }
    public void BossTurnMove()
    {
        Invoke("LastAttack", 3f);
    }
    private void LastAttack()
    {
        nowBox.LastBossAttack();
    }
    public void PlayerDie()
    {
        DiePanel.SetActive(true);
        print("플레이어 사망");
    }
}
