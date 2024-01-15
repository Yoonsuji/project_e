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
    private ShopPrefabSpawn shopPrefabSpawn;
    private ShopManager shopManager;
    private void Start()
    {
        ItemSpriteObject.sprite = itemData.itemSprite;
        shopPrefabSpawn = FindObjectOfType<ShopPrefabSpawn>();
        shopManager = FindObjectOfType<ShopManager>();
    }
    private void Update()
    {
        if (itemData.isItemTake == true)
        {
            ItemSpriteObject.color = new Color(1f, 1f, 1f, .5f);
            priceUi.text = "���ſϷ�";
        }
        else
        {
            if (itemData.selectedPriceType == ItemData.priceType.gold)
            {
                priceUi.text = itemData.itemPrice + "gold";
            }
            else if (itemData.selectedPriceType == ItemData.priceType.dia)
            {
                priceUi.text = itemData.itemPrice + "dia";
            }
        }
    }
    public void ItemClick()
    {
        shopPrefabSpawn.selectItemData = itemData;
    }
}
