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
    public ShopPrefabSpawn shopPrefabSpawn;
    public GameObject BuyPanel;
    public GameObject BuyBtn;
    public TMP_Text BuyText;
    public TMP_Text backText;
    public Image ItemPanel;
    private void Start()
    {
        selectItemData = null;
    }
    private void Update()
    {
        selectItemData = shopPrefabSpawn.selectItemData;
        if (selectItemData != null)
        {
            BuyPanel.SetActive(true);
            ItemPanel.sprite = selectItemData.itemSprite;
            if (selectItemData.isItemTake == true)
            {
                BuyText.text = "�����Ͽ����ϴ�.";
                backText.text = "������";
                BuyBtn.SetActive(false);
            }
            else
            {
                BuyText.text = selectItemData.itemName + "�� \n�����Ͻðڽ��ϱ�?";
                backText.text = "�ƴϿ�";
                BuyBtn.SetActive(true);
            }
        }
        else
        {
            BuyPanel.SetActive(false);
        }
    }
    public void ResetBtn()
    {
        for(int i = 0; i < shopPrefabSpawn.items.Count; i++)
        {
            shopPrefabSpawn.items[i].itemData.isItemTake = false;
        }
        goodsPrefab.gold = 0;
    }
    public void PlusBtn()
    {
        goodsPrefab.gold += 100;
    }
    public void BuyYes()
    {
        if (selectItemData.selectedPriceType == ItemData.priceType.gold)
        {
            if (goodsPrefab.gold >= selectItemData.itemPrice)
            {
                selectItemData.isItemTake = true;
                goodsPrefab.gold -= selectItemData.itemPrice;
            }
            else
            {
                print("��ȭ�� �����մϴ�.");
            }
        }
        else
        {
            if (goodsPrefab.dia >= selectItemData.itemPrice)
            {
                selectItemData.isItemTake = true;
                goodsPrefab.gold -= selectItemData.itemPrice;
            }
            else
            {
                print("��ȭ�� �����մϴ�.");
            }
        }
    }
    public void BuyNo()
    {
        shopPrefabSpawn.selectItemData = null;
        selectItemData = null;
    }
}
