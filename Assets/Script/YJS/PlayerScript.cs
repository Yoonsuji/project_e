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
                spawnedBoom.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.25f, 0f);
                exBox = towerBox;
                exBoom = spawnedBoom;
                Invoke("BoomDestroy", 0.3f);
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
        StartCoroutine(MoveObject(target.transform.position.x));
    }
    System.Collections.IEnumerator MoveObject(float targetX)
    {
        this.GetComponent<Animator>().SetBool("Drive", true);
        float elapsedTime = 0f;
        float startingX = transform.position.x;
        targetX -= 0.5f;

        while (elapsedTime < 1f)
        {
            float newX = Mathf.Lerp(startingX, targetX, elapsedTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            elapsedTime += Time.deltaTime * 1f;
            yield return null;
        }
        this.GetComponent<Animator>().SetBool("Drive", false);
        nowBox.Attacked();
    }

    private void BoomDestroy()
    {
        Destroy(exBoom.gameObject);
    }
    public void AttackAnime(bool startstop)
    {
        if (startstop == true)
        {
            this.GetComponent<Animator>().SetBool("Attack", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("Attack", false);
        }
    }

    public void DoMove()
    {
        this.GetComponent<Animator>().runtimeAnimatorController = capibaraAnime[0];
        powerText.color = originalTextColor;
        if (canMove == true)
        {
            nowBox = exBox;

            this.transform.position = new Vector3(nowBox.transform.position.x, nowBox.transform.position.y - 0.17f, 0f);
            if (nowBox.enemyCount != 0)
            {
                this.transform.position = new Vector3(nowBox.EnemyList[nowBox.enemyCount - 1].transform.position.x - 0.6f, this.transform.position.y, this.transform.position.z);
            }
            if (cameraMove.isFirst != true)
            {
                GameObject spawnedBoom = Instantiate(MoveBoom, this.transform.position, Quaternion.identity);
                spawnedBoom.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.25f, 0f);
                exBoom = spawnedBoom;
                Invoke("BoomDestroy", 0.3f);
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
