using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
public class TowerManager : MonoBehaviour
{
    public TowerBox towerBox;
    public TextAsset excel;
    private float spacing = 1f;
    private int lineSize, rowSize;
    string[,] dataTable;
    private void Start()
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
        print(lineSize);
        SpawnTowerBox();
    }
    void SpawnTowerBox()
    {
        //for(int i=0;i<dataTable[])
    }
}
