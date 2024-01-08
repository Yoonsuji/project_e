using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public TowerManager towerManager;
    public int num;
    public List<StageData> stageData = new List<StageData>();
    // Start is called before the first frame update
    void Start()
    {
        StageStatic.nowStageNum = num;
        for (int i = 0; i < stageData[StageStatic.nowStageNum-1].excel.Count ;i++)
        {
            towerManager.enemyCountList.Add(0);
        }
        towerManager.excel = stageData[StageStatic.nowStageNum - 1].excel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
