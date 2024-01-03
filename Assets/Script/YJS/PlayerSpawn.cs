using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public PlayerMove player;
    private void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        PlayerMove playerMoveComponent = player.GetComponent<PlayerMove>();
        playerMoveComponent.nowBox = this.gameObject;
        player.Move();
    }
}
