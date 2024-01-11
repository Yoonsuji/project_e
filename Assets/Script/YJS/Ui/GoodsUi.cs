using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoodsUi : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text diaText;
    public GoodsPrefab goodsPrefab;
    private void Update()
    {
        goldText.text = goodsPrefab.gold.ToString();
        diaText.text = goodsPrefab.dia.ToString();
    }
}
