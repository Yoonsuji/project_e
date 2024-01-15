using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    GameObject Player;
    public Player_Poo PooPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PooPlayer = Player.GetComponent<Player_Poo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeftBtnDown()
    {
        PooPlayer.LeftMove = true;
    }
    public void LeftBtnUp()
    {
        PooPlayer.LeftMove = false;
    }
    public void RightBtnDown()
    {
        PooPlayer.RightMove = true;
    }
    public void RightBtnUp()
    {
        PooPlayer.RightMove = false;
    }
}
