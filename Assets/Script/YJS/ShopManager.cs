using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public ItemData selectItemData;
    public ItemData selectCurrentCloth;
    public ItemData selectCurrentBackGround;
    public ItemData selectCurrentPet;
    public CapybaraCurrentItem capybaraCurrentItem;
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
        selectCurrentCloth = capybaraCurrentItem.currentCloth;
        selectCurrentBackGround = capybaraCurrentItem.currentBack;
        selectCurrentPet = capybaraCurrentItem.currentPet;
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
                BuyText.text = selectItemData.itemName + "��\n�����Ͽ����ϴ�.";
                backBtnText.text = "������";
                if (selectItemData.itemNumber != 2)
                {
                    if (selectItemData == capybaraCurrentItem.currentCloth || selectItemData == capybaraCurrentItem.currentBack || selectItemData == capybaraCurrentItem.currentPet)
                    {
                        buyBtnText.text = "��ü�ϱ�";
                    }
                    else
                    {
                        buyBtnText.text = "�����ϱ�";
                    }
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
            capybaraCurrentItem.currentCloth = null;
            capybaraCurrentItem.currentBack = null;
            capybaraCurrentItem.currentPet = null;
            shopPrefabSpawn.items[i].itemData.isItemTake = false;
            shopPrefabSpawn.items[i].itemData.Activation = false;
        }
        goodsPrefab.gold = 0;
        goodsPrefab.dia = 0;
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
                    if (selectItemData.selectedItemType == ItemData.itemType.furniture)
                    {
                        selectItemData.Activation = true;
                    }
                    else
                    {
                        if (selectItemData.selectedItemType == ItemData.itemType.cloth)
                        {
                            capybaraCurrentItem.currentCloth = selectItemData;
                        }
                        else if(selectItemData.selectedItemType == ItemData.itemType.background)
                        {
                            capybaraCurrentItem.currentBack = selectItemData;
                        }
                        else if (selectItemData.selectedItemType == ItemData.itemType.pet)
                        {
                            capybaraCurrentItem.currentPet = selectItemData;
                        }
                    }
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
                    goodsPrefab.dia -= selectItemData.itemPrice;
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
            else if(selectItemData.selectedItemType == ItemData.itemType.cloth)
            {
                if (selectItemData == capybaraCurrentItem.currentCloth)
                {
                    capybaraCurrentItem.currentCloth = null;
                }
                else
                {
                    Select(ItemData.itemType.cloth);
                }
            }
            else if(selectItemData.selectedItemType == ItemData.itemType.background)
            {
                if (selectItemData == capybaraCurrentItem.currentBack)
                {
                    capybaraCurrentItem.currentBack = null;
                }
                else
                {
                    Select(ItemData.itemType.background);
                }
            }
            else if(selectItemData.selectedItemType == ItemData.itemType.pet)
            {
                if (selectItemData == capybaraCurrentItem.currentPet)
                {
                    capybaraCurrentItem.currentPet = null;
                }
                else
                {
                    Select(ItemData.itemType.pet);
                }
            }
        }
    }
    private void Select(ItemData.itemType type)
    {
        if (type == ItemData.itemType.cloth)
        {
            selectCurrentCloth = selectItemData;
            capybaraCurrentItem.currentCloth = selectCurrentCloth;
        }
        else if(type == ItemData.itemType.background)
        {
            selectCurrentBackGround = selectItemData;
            capybaraCurrentItem.currentBack = selectCurrentBackGround;
        }
        else if (type == ItemData.itemType.pet)
        {
            selectCurrentPet = selectItemData;
            capybaraCurrentItem.currentPet = selectCurrentPet;
        }
    }
    public void BuyNo()
    {
        shopPrefabSpawn.selectItemData = null;
        selectItemData = null;
    }
}
