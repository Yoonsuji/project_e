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
    private TowerBox exBox;
    private GameObject exBoom;
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
            this.GetComponent<Animator>().runtimeAnimatorController = null;
            Color currentColor = powerText.color;
            currentColor.a = 0f;
            powerText.color = currentColor;
            GameObject spawnedBoom = Instantiate(MoveBoom, this.transform.position, Quaternion.identity);
            spawnedBoom.transform.position = nowBox.transform.position + Vector3.down * 0.25f;
            exBox = towerBox;
            exBoom = spawnedBoom;
            Invoke("Boom", 0.5f);
            Invoke("DoMove", 2f);
        }
        else
        {
            exBox = towerBox;
            DoMove();
        }
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

            if (nowBox.enemyCount == 0)
            {
                this.transform.position = nowBox.transform.position;
            }
            else
            {
                this.transform.position = nowBox.EnemyList[nowBox.enemyCount - 1].transform.position + Vector3.left * 1f;
            }
            this.transform.position = nowBox.transform.position + Vector3.down * 0.15f;
            if (cameraMove.isFirst != true)
            {
                GameObject spawnedBoom = Instantiate(MoveBoom, this.transform.position, Quaternion.identity);
                spawnedBoom.transform.position = nowBox.transform.position + Vector3.down * 0.25f;
                exBoom = spawnedBoom;
                Invoke("Boom", 0.5f);
            }
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
        print("플레이어 사망");
    }
}
