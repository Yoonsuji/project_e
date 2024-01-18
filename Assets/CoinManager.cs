using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public GoodsPrefab goodsPrefab;
    public TextMeshProUGUI coinText;
    // Start is called before the first frame update
    public void UpdateCoinText(int amount)
    {
        goodsPrefab.gold += amount;
        int currentCoins = int.Parse(coinText.text);
        currentCoins += amount;
        coinText.text = currentCoins.ToString();
    }
}
