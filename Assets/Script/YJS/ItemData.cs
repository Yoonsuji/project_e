using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    public int itemNumber;
    public string itemName;
    public enum priceType
    {
        gold, dia
    }
    public priceType selectedPriceType;
    public int itemPrice;
    public Sprite itemSprite;
    public bool isItemTake;
}
