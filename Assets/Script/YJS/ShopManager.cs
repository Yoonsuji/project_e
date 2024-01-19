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
                BuyText.text = selectItemData.itemName + "를\n구매하였습니다.";
                backBtnText.text = "나가기";
                if (selectItemData.itemNumber != 2)
                {
                    if (selectItemData == capybaraCurrentItem.currentCloth || selectItemData == capybaraCurrentItem.currentBack || selectItemData == capybaraCurrentItem.currentPet)
                    {
                        buyBtnText.text = "해체하기";
                    }
                    else
                    {
                        buyBtnText.text = "장착하기";
                    }
                }
                else
                {
                    if (selectItemData.Activation == true)
                    {
                        buyBtnText.text = "비활성화";
                    }
                    else
                    {
                        buyBtnText.text = "활성화";
                    }
                }
            }
            else
            {
                BuyText.text = selectItemData.itemName + "를 \n구매하시겠습니까?";
                buyBtnText.text = "예";
                backBtnText.text = "아니오";
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
                    print("재화가 부족합니다.");
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
                    print("재화가 부족합니다.");
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
