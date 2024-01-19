using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemPrefab : MonoBehaviour
{
    public Image ItemSpriteObject;
    public ItemData itemData;
    public GameObject priceUi;
    public GameObject goodIcon;
    public GameObject newText;
    public CapybaraCurrentItem capybaraCurrentItem;
    public GameObject GoodsIcon;
    public Sprite gold;
    public Sprite gam;
    private SpriteRenderer spriteRenderer;
    private ShopPrefabSpawn shopPrefabSpawn;
    private ShopManager shopManager;
    private void Start()
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(0.9f, 0.9f, 1f);
        ItemSpriteObject.sprite = itemData.itemSprite;
        shopPrefabSpawn = FindObjectOfType<ShopPrefabSpawn>();
        shopManager = FindObjectOfType<ShopManager>();
    }
    private void Update()
    {
        if (itemData.isItemTake == true)
        {
            if (itemData.selectedItemType != ItemData.itemType.furniture)
            {
                if (itemData == capybaraCurrentItem.currentBack || itemData == capybaraCurrentItem.currentCloth || itemData == capybaraCurrentItem.currentPet)
                {
                    ItemSpriteObject.color = new Color(1f, 1f, 1f, .5f);
                }
                else
                {
                    ItemSpriteObject.color = new Color(1f, 1f, 1f, 1f);
                }
            }
            else
            {
                if (itemData.Activation == true)
                {
                    ItemSpriteObject.color = new Color(1f, 1f, 1f, .5f);
                }
                else
                {
                    ItemSpriteObject.color = new Color(1f, 1f, 1f, 1f);
                }
            }
            priceUi.gameObject.SetActive(false);
            goodIcon.SetActive(false);
            newText.gameObject.SetActive(true);
        }
        else
        {
            if (itemData.selectedPriceType == ItemData.priceType.gold)
            {
                GoodsIcon.GetComponent<Image>().sprite = gold;
            }
            else if (itemData.selectedPriceType == ItemData.priceType.dia)
            {
                GoodsIcon.GetComponent<Image>().sprite = gam;
            }
        }
    }
    public void ItemClick()
    {
        shopPrefabSpawn.selectItemData = itemData;
    }
}
