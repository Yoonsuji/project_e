using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public TowerBox StartBox;
    private void Start()
    {
        TowerBox spawnedTower = Instantiate(StartBox, this.transform.position, Quaternion.identity);
    }
}
