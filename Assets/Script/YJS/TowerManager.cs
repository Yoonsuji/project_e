using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
public class TowerManager : MonoBehaviour
{
    public TowerBox towerBox;
    public List<TextAsset> excel = new List<TextAsset>();
    private float spacing = 1f;
    private int lineSize, rowSize;
    private int count = 0;
    string[,] dataTable;
    private void Start()
    {
        for(int i = 0; i < excel.Count; i++)
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
                    spawnedTower.GetComponent<TowerBox>().SpawnEnemy(int.Parse(dataTable[j, 1]), int.Parse(dataTable[j, 2]));
                }
            }
            spawnedTower.transform.parent = transform;
            spawnedTower.transform.Translate(new Vector3(2.7f*(float)towerNumber, 2.2f*(float)i, 0f));
        }
    }
}
