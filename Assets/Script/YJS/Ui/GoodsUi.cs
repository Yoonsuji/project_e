using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoodsUi : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text diaText;

    private void Update()
    {
        goldText.text = GoodsStatic.gold.ToString();
        diaText.text = GoodsStatic.dia.ToString();
    }
}
