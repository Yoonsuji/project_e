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
            //this.gameObject.SetActive(false);
            //yield return new WaitForSeconds(0.3f);
            nowBox = towerBox;
            this.transform.position = nowBox.transform.position;
            //this.gameObject.SetActive(true);
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
        //플레이어 사망
    }
}
