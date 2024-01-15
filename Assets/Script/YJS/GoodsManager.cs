using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsManager : MonoBehaviour
{
    public GoodsPrefab goods;
    public int goodsVolume;

    public void GetGold()
    {
        goods.gold += goodsVolume;
    }
    public void GetDia()
    {
        goods.dia += goodsVolume;
    }
}
