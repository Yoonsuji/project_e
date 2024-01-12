using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public TowerManager towerManager;
    public int num;
    public List<StageData> stageData = new List<StageData>();
    private CameraMove cameraMove;
    void Start()
    {
        cameraMove = FindObjectOfType<CameraMove>();
        for (int i = 0; i < stageData[StageStatic.nowStageNum-1].excel.Count ;i++)
        {
            towerManager.enemyCountList.Add(0);
        }
        towerManager.excel = stageData[StageStatic.nowStageNum - 1].excel;
        cameraMove.LoadStart();
        towerManager.LoadStart();
    }
    public void NextStage()
    {
        StageStatic.nowStageNum++;
        SceneManager.LoadScene("HeroWars_Tower");
    }
}
