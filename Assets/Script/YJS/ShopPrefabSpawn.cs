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
    private List<ItemPrefab> clothItemPrefabs = new List<ItemPrefab>();
    private List<ItemPrefab> furnitureItemPrefabs = new List<ItemPrefab>();
    private List<ItemPrefab> backgroundItemPrefabs = new List<ItemPrefab>();
    private List<ItemPrefab> petItemPrefabs = new List<ItemPrefab>();
    public ItemPrefab itemPrefab;
    private void Start()
    {
        selectItemData = null;
        for (int i = 0; i < clothShopData.Count; i++)
        {
            ItemPrefab spawnedPrefab = Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
            clothItemPrefabs.Add(spawnedPrefab);
            spawnedPrefab.transform.SetParent(transform);
            spawnedPrefab.itemData = clothShopData[i];
            //spawnedPrefab.transform.Translate(new Vector3(-210f + (i % 3) * 210f, 190f - (i / 3) * 210f, 0f));
        }
        for (int i = 0; i < furnitureShopData.Count; i++)
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
    public void ClothShop()
    {
        for (int i = 0; i < clothItemPrefabs.Count; i++)
        {
            clothItemPrefabs[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < furnitureItemPrefabs.Count; i++)
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
}
