using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPrefabSpawn : MonoBehaviour
{
    public ItemData selectItemData;
    public List<ItemData> clothShopData = new List<ItemData>();
    public List<ItemData> furnitureShopData = new List<ItemData>();
    public List<ItemData> backgroundShopData = new List<ItemData>();
    public List<ItemData> petShopData = new List<ItemData>();
    public List<ItemPrefab> items = new List<ItemPrefab>();
    public ItemPrefab itemPrefab;
    private void Start()
    {
        selectItemData = null;
        for (int i = 0; i < clothShopData.Count; i++)
        {
            ItemPrefab spawnedPrefab = Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
            items.Add(spawnedPrefab);
            spawnedPrefab.transform.SetParent(transform);
            spawnedPrefab.itemData = clothShopData[i];
        }
        for (int i = 0; i < furnitureShopData.Count; i++)
        {
            ItemPrefab spawnedPrefab = Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
            items.Add(spawnedPrefab);
            spawnedPrefab.transform.SetParent(transform);
            spawnedPrefab.itemData = furnitureShopData[i];
        }
        for (int i = 0; i < backgroundShopData.Count; i++)
        {
            ItemPrefab spawnedPrefab = Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
            items.Add(spawnedPrefab);
            spawnedPrefab.transform.SetParent(transform);
            spawnedPrefab.itemData = backgroundShopData[i];
        }
        for (int i = 0; i < petShopData.Count; i++)
        {
            ItemPrefab spawnedPrefab = Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
            items.Add(spawnedPrefab);
            spawnedPrefab.transform.SetParent(transform);
            spawnedPrefab.itemData = petShopData[i];
        }
        ClothShop();
    }
    public void ClothShop()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemData.itemNumber == 1)
            {
                items[i].gameObject.SetActive(true);
            }
            else
            {
                items[i].gameObject.SetActive(false);
            }
        }
    }
    public void FurnitureShop()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemData.itemNumber == 2)
            {
                items[i].gameObject.SetActive(true);
            }
            else
            {
                items[i].gameObject.SetActive(false);
            }
        }
    }
    public void BackgroundShop()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemData.itemNumber == 3)
            {
                items[i].gameObject.SetActive(true);
            }
            else
            {
                items[i].gameObject.SetActive(false);
            }
        }
    }
    public void PetShop()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemData.itemNumber == 4)
            {
                items[i].gameObject.SetActive(true);
            }
            else
            {
                items[i].gameObject.SetActive(false);
            }
        }
    }
}
