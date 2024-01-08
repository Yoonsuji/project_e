using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ItemData selectItemData;
    public GameObject BuyButton;
    public List<ItemData> shopDataList = new List<ItemData>();
    public ItemPrefab itemPrefab;
    private void Start()
    {
        BuyButton.SetActive(false);
        selectItemData = null;
        for(int i = 0; i < shopDataList.Count; i++)
        {
            ItemPrefab spawnedPrefab = Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
            spawnedPrefab.transform.SetParent(transform);
            spawnedPrefab.itemData = shopDataList[i];
            spawnedPrefab.transform.Translate(new Vector3(-420f + (i % 3) * 420f, 420f - (i / 3) * 420f, 0f));
        }
    }
    public void ItemSelect(ItemData itemData)
    {
        BuyButton.SetActive(true);
    }
}
