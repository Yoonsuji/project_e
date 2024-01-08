using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(fileName = "Stage Data", menuName = "Scriptable Object/Stage Data", order = int.MaxValue)]
public class StageData : ScriptableObject
{
    public int stageNum;
    public List<TextAsset> excel = new List<TextAsset>();
}