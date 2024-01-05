using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
public class TowerManager : MonoBehaviour
{
    public TowerBox towerBox;
    public PlayerScript player;
    public CameraMove cameraMove;
    public List<TextAsset> excel = new List<TextAsset>();
    public List<int> enemyCountList = new List<int>();
    private float spacing = 1f;
    private int lineSize, rowSize;
    private int count = 0;
    private TowerBox BossTower;
    public bool isBossTurn = false;
    string[,] dataTable;
    private void Start()
    {
        for (int i = 0; i < excel.Count; i++)
        {
            enemyCountList.Add(0);
        }
        for (int i = 0; i < excel.Count; i++)
        {
            DataTable(excel[i], i);
        }
    }
    private void DataTable(TextAsset excel, int towerNumber)
    {
        string DataTable = excel.text.Substring(0, excel.text.Length - 1);
        string[] line = DataTable.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split(',').Length;
        dataTable = new string[lineSize, rowSize];
        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split(',');
            for (int j = 0; j < rowSize; j++)
            {
                dataTable[i, j] = row[j];
            }
        }
        SpawnTowerBox(towerNumber);
    }
    void SpawnTowerBox(int towerNumber)
    {
        for (int i = 0; i < int.Parse(dataTable[lineSize - 1, 0]); i++)
        {
            TowerBox spawnedTower = Instantiate(towerBox, this.transform.position, Quaternion.identity);
            for(int j = 0; j < lineSize; j++)
            {
                if (int.Parse(dataTable[j, 0]) == i + 1)
                {
                    spawnedTower.GetComponent<TowerBox>().SpawnEnemy(float.Parse(dataTable[j, 1]), int.Parse(dataTable[j, 2]));
                    if (float.Parse(dataTable[j, 1]) == 0)
                    {
                        spawnedTower.isBossBox = true;
                    }
                    enemyCountList[towerNumber]++;
                }
            }
            spawnedTower.towerNumber = towerNumber;
            spawnedTower.transform.parent = transform;
            spawnedTower.transform.Translate(new Vector3(2.7f*(float)towerNumber, 2.2f*(float)i, 0f));
        }
    }
    public void EnemyCheck()
    {
        if (enemyCountList[player.nowTowerNumber] == 0)
        {
            if (player.nowBox.towerNumber == excel.Count - 1)
            {
                print("Å¬¸®¾î!!");
            }
            else
            {
                if (enemyCountList[player.nowTowerNumber + 1] == 1)
                {
                    BossTower = FindObjectOfType<TowerBox>();
                    BossTower.isBossTurn();
                }
                cameraMove.NextTower();
            }
        }
    }
}
