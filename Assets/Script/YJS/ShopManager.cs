using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public ItemData selectItemData;
    public ItemData selectCurrentCloth;
    public Image ChrPanel;
    public GoodsPrefab goodsPrefab;
    public ShopPrefabSpawn shopPrefabSpawn;
    public GameObject BuyPanel;
    public TMP_Text BuyText;
    public TMP_Text buyBtnText;
    public TMP_Text backBtnText;
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
                backBtnText.text = "������";
                if (selectItemData.itemNumber != 2)
                {
                    buyBtnText.text = "�����ϱ�";
                }
                else
                {
                    if (selectItemData.Activation == true)
                    {
                        buyBtnText.text = "��Ȱ��ȭ";
                    }
                    else
                    {
                        buyBtnText.text = "Ȱ��ȭ";
                    }
                }
            }
            else
            {
                BuyText.text = selectItemData.itemName + "�� \n�����Ͻðڽ��ϱ�?";
                buyBtnText.text = "��";
                backBtnText.text = "�ƴϿ�";
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
            shopPrefabSpawn.items[i].itemData.Activation = false;
        }
        goodsPrefab.gold = 0;
    }
    public void PlusBtn()
    {
        goodsPrefab.gold += 100;
    }
    public void BuyYes()
    {
        if (selectItemData.isItemTake != true)
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
        else
        {
            if (selectItemData.selectedItemType == ItemData.itemType.furniture)
            {
                if (selectItemData.Activation == true)
                {
                    selectItemData.Activation = false;
                }
                else
                {
                    selectItemData.Activation = true;
                }
            }
            else
            {
                selectCurrentCloth = selectItemData;
            }
        }
    }
    public void BuyNo()
    {
        shopPrefabSpawn.selectItemData = null;
        selectItemData = null;
    }
}
