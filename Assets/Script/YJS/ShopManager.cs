using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public ItemData selectItemData;
    public GameObject BuyButton;
    public Image ChrPanel;
    public TMP_Text buyBtnText;
    public GoodsPrefab goodsPrefab;
    public List<ItemData> goldShopData = new List<ItemData>();
    public List<ItemData> diaShopData = new List<ItemData>();
    private List<ItemPrefab> goldItemPrefabs = new List<ItemPrefab>();
    private List<ItemPrefab> diaItemPrefabs = new List<ItemPrefab>();
    public ItemPrefab itemPrefab;
    public enum nowShopType
    {
        gold, dia
    }
    public nowShopType selectedShopType;
    private void Start()
    {
        BuyButton.SetActive(false);
        selectItemData = null;
        selectedShopType = nowShopType.gold;
        for(int i = 0; i < goldShopData.Count; i++)
        {
            ItemPrefab spawnedPrefab = Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
            goldItemPrefabs.Add(spawnedPrefab);
            spawnedPrefab.transform.SetParent(transform);
            spawnedPrefab.itemData = goldShopData[i];
            spawnedPrefab.transform.Translate(new Vector3(-420f + (i % 3) * 420f, 420f - (i / 3) * 420f, 0f));
        }
        for(int i = 0; i < diaShopData.Count; i++)
        {
            ItemPrefab spawnedPrefab = Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
            diaItemPrefabs.Add(spawnedPrefab);
            spawnedPrefab.transform.SetParent(transform);
            spawnedPrefab.itemData = diaShopData[i];
            spawnedPrefab.transform.Translate(new Vector3(-420f + (i % 3) * 420f, 420f - (i / 3) * 420f, 0f));
        }
        GoldShop();
    }
    private void Update()
    {
        if (selectItemData != null)
        {
            ChrPanel.sprite = selectItemData.itemSprite;
            buyBtnText.text = selectItemData.itemPrice.ToString() + "$ BUY";
            BuyButton.SetActive(true);
        }
    }
    public void BuyBtn()
    {
        Buying(selectItemData.selectedPriceType, selectItemData.itemPrice);
    }
    private void Buying(ItemData.priceType type , int price)
    {
        if (type == ItemData.priceType.gold)
        {
            if (goodsPrefab.gold >= price)
            {
                SuccessBuy(price);
            }
        }
        else if (type == ItemData.priceType.dia)
        {
            if (goodsPrefab.dia >= price)
            {
                SuccessBuy(price);
            }
        }
    }
    private void SuccessBuy(int price)
    {
        print(selectItemData.itemName + "구매완료!!");
        goodsPrefab.gold -= price;
        selectItemData.isItemTake = true;
        selectItemData = null;
    }
    public void GoldShop()
    {
        selectedShopType = nowShopType.gold;
        for (int i = 0; i < goldItemPrefabs.Count; i++)
        {
            goldItemPrefabs[i].gameObject.SetActive(true);
        }
        for(int i = 0; i < diaItemPrefabs.Count; i++)
        {
            diaItemPrefabs[i].gameObject.SetActive(false);
        }
    }
    public void DiaShop()
    {
        selectedShopType = nowShopType.dia;
        for (int i = 0; i < goldItemPrefabs.Count; i++)
        {
            goldItemPrefabs[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < diaItemPrefabs.Count; i++)
        {
            diaItemPrefabs[i].gameObject.SetActive(true);
        }
    }

    public void ResetBtn()
    {
        for(int i = 0; i < goldShopData.Count; i++)
        {
            goldShopData[i].isItemTake = false;
        }
        goodsPrefab.gold = 0;
    }
    public void PlusBtn()
    {
        goodsPrefab.gold += 100;
    }
}
