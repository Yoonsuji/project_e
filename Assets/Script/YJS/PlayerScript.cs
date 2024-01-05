using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    Vector3 mousePosition;
    private Vector3 initialPosition;
    public TowerBox nowBox;
    public int nowTowerNumber;
    public CameraMove cameraMove;
    public int playerPower;
    public Text powerText;
    public bool canMove;

    private void Start()
    {
        canMove = true;
    }

    public void Move(TowerBox towerBox)
    {
        if (canMove == true)
        {
            nowBox = towerBox;
            if (nowBox.enemyCount == 0)
            {
                this.transform.position = nowBox.transform.position;
            }
            else
            {
                this.transform.position = nowBox.EnemyList[nowBox.enemyCount - 1].transform.position + Vector3.left * 0.3f;
            }
            nowBox.Attacked();
        }
    }
    private void Update()
    {
        powerText.text = playerPower.ToString();
        if (cameraMove.isActive == true)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
        nowTowerNumber = nowBox.towerNumber;
    }
    public void PlayerDie()
    {
        print("플레이어 사망");
    }
}
