using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    private void Start()
    {
        Instantiate(player, this.transform.position, Quaternion.identity);
        PlayerMove playerMoveComponent = player.GetComponent<PlayerMove>();
        playerMoveComponent.nowBox = this.gameObject;
    }
}
