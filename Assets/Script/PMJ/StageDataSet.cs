using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StageDataSet : MonoBehaviour
{
    public TextMeshProUGUI[] stageTxt;
    public StagePrefab[] stageData;
    public Slider[] stageSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < stageSlider.Length; i++)
        {
            if (stageData[i].currentStage > stageData[i].maxStage) stageData[i].currentStage = stageData[i].maxStage;
            stageTxt[i].text = "스테이지 : " + stageData[i].currentStage.ToString() + "/" + stageData[i].maxStage.ToString();
            stageSlider[i].maxValue = stageData[i].maxStage;
            stageSlider[i].value = stageData[i].currentStage;
        }
    }
}
