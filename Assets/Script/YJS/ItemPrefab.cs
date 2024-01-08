using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemPrefab : MonoBehaviour
{
    public Image ItemSpriteObject;
    public ItemData itemData;
    private SpriteRenderer spriteRenderer;
    private ShopManager shopManager;
    private void Start()
    {
        ItemSpriteObject.sprite = itemData.itemSprite;
        shopManager = FindObjectOfType<ShopManager>();
    }
    public void ItemClick()
    {
        shopManager.selectItemData = itemData;
    }
}
