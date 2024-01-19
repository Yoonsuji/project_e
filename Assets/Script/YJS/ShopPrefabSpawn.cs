using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPrefabSpawn : MonoBehaviour
{
    public ItemData selectItemData;
    public CapybaraCurrentItem capybaraCurrentItem;
    public List<ItemData> clothShopData = new List<ItemData>();
    public List<ItemData> furnitureShopData = new List<ItemData>();
    public List<ItemData> backgroundShopData = new List<ItemData>();
    public List<ItemData> petShopData = new List<ItemData>();
    public List<ItemPrefab> items = new List<ItemPrefab>();
    public ItemPrefab itemPrefab;
    public enum shopType
    {
        cloth, furniture, background, pet
    }
    public shopType selectShop;
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
    private void Update()
    {
        for (int i = 0; i < clothShopData.Count; i++)
        {
            if(capybaraCurrentItem.currentCloth == clothShopData[i])
            {
                clothShopData[i].Activation = true;
            }
            else
            {
                clothShopData[i].Activation = false;
            }
        }
        for (int i = 0; i < backgroundShopData.Count; i++)
        {
            if (capybaraCurrentItem.currentBack == backgroundShopData[i])
            {
                backgroundShopData[i].Activation = true;
            }
            else
            {
                backgroundShopData[i].Activation = false;
            }
        }
        for (int i = 0; i < petShopData.Count; i++)
        {
            if (capybaraCurrentItem.currentPet == petShopData[i])
            {
                petShopData[i].Activation = true;
            }
            else
            {
                petShopData[i].Activation = false;
            }
        }
    }
    public void ClothShop()
    {
        selectShop = shopType.cloth;
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
        selectShop = shopType.furniture;
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
        selectShop = shopType.background;
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
        selectShop = shopType.pet;
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
