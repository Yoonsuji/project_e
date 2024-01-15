using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemPrefab : MonoBehaviour
{
    public Image ItemSpriteObject;
    public ItemData itemData;
    public TMP_Text priceUi;
    private SpriteRenderer spriteRenderer;
    private ShopPrefabSpawn shopManager;
    private void Start()
    {
        ItemSpriteObject.sprite = itemData.itemSprite;
        shopManager = FindObjectOfType<ShopPrefabSpawn>();
        if (itemData.selectedPriceType == ItemData.priceType.gold)
        {
            priceUi.text = itemData.itemPrice + "gold";
        }
        else if (itemData.selectedPriceType == ItemData.priceType.dia)
        {
            priceUi.text = itemData.itemPrice + "dia";
        }
    }
    private void Update()
    {
        if (itemData.isItemTake == true)
        {
            ItemSpriteObject.color = new Color(1f,1f,1f,.5f);
        }
    }
    public void ItemClick()
    {
        if (itemData.isItemTake == false)
        {
            shopManager.selectItemData = itemData;
        }
        else
        {
            print("이미구매완료");
        }
    }
}
