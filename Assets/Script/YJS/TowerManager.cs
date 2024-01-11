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
    public GameObject ClearPanel;
    public GameObject towerShadow;
    private float spacing = 1f;
    private int lineSize, rowSize;
    private int count = 0;
    private TowerBox BossTower;
    public bool isBossTurn = false;
    string[,] dataTable;
    private void Start()
    {
        
    }
    public void LoadStart()
    {
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
                    if (j == lineSize-1)
                    {
                        spawnedTower.isTopBox = true;
                    }
                    enemyCountList[towerNumber]++;
                }
            }
            spawnedTower.towerNumber = towerNumber;
            spawnedTower.transform.parent = transform;
            spawnedTower.transform.Translate(new Vector3(2.7f*(float)towerNumber, 1.97f*(float)i, 0f));
        }
        /*GameObject towershadow = Instantiate(towerShadow, this.transform.position, Quaternion.identity);
        towershadow.transform.parent = transform;
        towershadow.transform.Translate(new Vector3(-0.02f + (2.7f * towerNumber), -1f, 0f));*/
    }
    public void EnemyCheck()
    {
        if (enemyCountList[player.nowBox.towerNumber] == 0)
        {
            if (player.nowBox.towerNumber == excel.Count - 1)
            {
                print("Å¬¸®¾î!!");
                Win();
            }
            else
            {
                if (enemyCountList[player.nowBox.towerNumber + 1] == 1)
                {
                    BossTower = FindObjectOfType<TowerBox>();
                    BossTower.isBossTurn();
                }
                cameraMove.NextTower();
            }
        }
    }
    public void Win()
    {
        ClearPanel.SetActive(true);
    }
}
