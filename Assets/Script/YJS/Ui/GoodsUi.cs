using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoodsUi : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text diaText;
    private ShopManager shopManager;

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
    }
    private void Update()
    {
        goldText.text = shopManager.goodsPrefab.gold.ToString();
        diaText.text = shopManager.goodsPrefab.dia.ToString();
    }
}
