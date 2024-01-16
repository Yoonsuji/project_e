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
    public GameObject BossGunEffect;
    public GameObject NormalGunEffect;
    private TowerBox exBox;
    private TowerBox previousBox = null;
    private Color originalTextColor;
    private Color changeColor;
    private GameObject effect;

    private void Start()
    {
        originalTextColor = new Color(255f, 255f, 255f, 255f);
        changeColor = originalTextColor;
        changeColor.a = 0f;
        changeColor.r = originalTextColor.r;
        changeColor.g = originalTextColor.g;
        changeColor.b = originalTextColor.b;

        this.GetComponent<Animator>().runtimeAnimatorController = capibaraAnime[0];
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
                powerText.color = changeColor;
                GameObject spawnedBoom = Instantiate(MoveBoom, this.transform.position, Quaternion.identity);
                spawnedBoom.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.25f, 0f);
                exBox = towerBox;
                Invoke("DoMove", 1f);
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
        targetX -= 0.9f;

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
    public void AttackAnime(bool startstop)
    {
        if (startstop == true)
        {
            this.GetComponent<Animator>().SetBool("Attack", true);
            GameObject spawnedEffect = Instantiate(NormalGunEffect, this.transform.position, Quaternion.identity);
            spawnedEffect.transform.parent = transform;
            spawnedEffect.transform.Translate(new Vector3(-0.17f, 0f, 0f));
            effect = spawnedEffect;
        }
        else
        {
            this.GetComponent<Animator>().SetBool("Attack", false);
            if (effect != null)
            {
                Destroy(effect.gameObject);
            }
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
                this.transform.position = new Vector3(nowBox.EnemyList[nowBox.enemyCount - 1].transform.position.x - 0.9f, this.transform.position.y, this.transform.position.z);
            }
            if (cameraMove.isFirst != true)
            {
                GameObject spawnedBoom = Instantiate(MoveBoom, this.transform.position, Quaternion.identity);
                spawnedBoom.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.25f, 0f);
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
        GameObject spawnedGun = Instantiate(BossGunEffect, this.transform.position, Quaternion.identity);
        spawnedGun.transform.position = new Vector3(6f, -0.6f, 0f);
        Invoke("LastAttack", 7f);
    }
    private void LastAttack()
    {
        nowBox.LastBossAttack();
    }
    public void PlayerDie()
    {
        this.GetComponent<Animator>().SetBool("Die", true);
        Invoke("Die", 1.8f);
    }
    private void Die()
    {
        canMove = false;
        DiePanel.SetActive(true);
        print("플레이어 사망");
    }
}
