using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public ItemData selectItemData;
    public Image ChrPanel;
    public GoodsPrefab goodsPrefab;
    public List<ItemData> clothShopData = new List<ItemData>();
    public List<ItemData> furnitureShopData = new List<ItemData>();
    public List<ItemData> backgroundShopData = new List<ItemData>();
    public List<ItemData> petShopData = new List<ItemData>();
    private List<ItemPrefab> clothItemPrefabs = new List<ItemPrefab>();
    private List<ItemPrefab> furnitureItemPrefabs = new List<ItemPrefab>();
    private List<ItemPrefab> backgroundItemPrefabs = new List<ItemPrefab>();
    private List<ItemPrefab> petItemPrefabs = new List<ItemPrefab>();
    public ItemPrefab itemPrefab;
    public enum nowShopType
    {
        gold, dia
    }
    private void Start()
    {
        selectItemData = null;
        for(int i = 0; i < clothShopData.Count; i++)
        {
            ItemPrefab spawnedPrefab = Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
            clothItemPrefabs.Add(spawnedPrefab);
            spawnedPrefab.transform.SetParent(transform);
            spawnedPrefab.itemData = clothShopData[i];
            //spawnedPrefab.transform.Translate(new Vector3(-210f + (i % 3) * 210f, 190f - (i / 3) * 210f, 0f));
        }
        for(int i = 0; i < furnitureShopData.Count; i++)
        {
            ItemPrefab spawnedPrefab = Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
            furnitureItemPrefabs.Add(spawnedPrefab);
            spawnedPrefab.transform.SetParent(transform);
            spawnedPrefab.itemData = furnitureShopData[i];
            //spawnedPrefab.transform.Translate(new Vector3(-210f + (i % 3) * 210f, 190f - (i / 3) * 210f, 0f));
        }/*
        for (int i = 0; i < backgroundShopData.Count; i++)
        {
            ItemPrefab spawnedPrefab = Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
            backgroundItemPrefabs.Add(spawnedPrefab);
            spawnedPrefab.transform.SetParent(transform);
            spawnedPrefab.itemData = backgroundShopData[i];
            spawnedPrefab.transform.Translate(new Vector3(-210f + (i % 3) * 210f, 190f - (i / 3) * 210f, 0f));
        }
        for (int i = 0; i < petShopData.Count; i++)
        {
            ItemPrefab spawnedPrefab = Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
            petItemPrefabs.Add(spawnedPrefab);
            spawnedPrefab.transform.SetParent(transform);
            spawnedPrefab.itemData = petShopData[i];
            spawnedPrefab.transform.Translate(new Vector3(-210f + (i % 3) * 210f, 190f - (i / 3) * 210f, 0f));
        }*/
        ClothShop();
    }
    private void Update()
    {
        if (selectItemData != null)
        {
            ChrPanel.sprite = selectItemData.itemSprite;
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
        print(selectItemData.itemName + "���ſϷ�!!");
        goodsPrefab.gold -= price;
        selectItemData.isItemTake = true;
        selectItemData = null;
    }
    public void ClothShop()
    {
        for (int i = 0; i < clothItemPrefabs.Count; i++)
        {
            clothItemPrefabs[i].gameObject.SetActive(true);
        }
        for(int i = 0; i < furnitureItemPrefabs.Count; i++)
        {
            furnitureItemPrefabs[i].gameObject.SetActive(false);
        }
    }
    public void FurnitureShop()
    {
        for (int i = 0; i < clothItemPrefabs.Count; i++)
        {
            clothItemPrefabs[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < furnitureItemPrefabs.Count; i++)
        {
            furnitureItemPrefabs[i].gameObject.SetActive(true);
        }
    }
    public void BackgroundShop()
    {
        for (int i = 0; i < clothItemPrefabs.Count; i++)
        {
            clothItemPrefabs[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < furnitureItemPrefabs.Count; i++)
        {
            furnitureItemPrefabs[i].gameObject.SetActive(true);
        }
    }
    public void PetShop()
    {
        for (int i = 0; i < clothItemPrefabs.Count; i++)
        {
            clothItemPrefabs[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < furnitureItemPrefabs.Count; i++)
        {
            furnitureItemPrefabs[i].gameObject.SetActive(true);
        }
    }
    public void ResetBtn()
    {
        for(int i = 0; i < clothShopData.Count; i++)
        {
            clothShopData[i].isItemTake = false;
        }
        goodsPrefab.gold = 0;
    }
    public void PlusBtn()
    {
        goodsPrefab.gold += 100;
    }
}
