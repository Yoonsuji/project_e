using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBtnManager : MonoBehaviour
{
    public ShopPrefabSpawn shopPrefabSpawn;
    public List<GameObject> shopTypeBtn = new List<GameObject>();
    public List<Sprite> changeSprite = new List<Sprite>();
    public List<Sprite> originalSprites = new List<Sprite>();
    public float c1;
    public float c2;
    public float o1;
    public float o2;
    private void Update()
    {
        if (shopPrefabSpawn.selectShop == ShopPrefabSpawn.shopType.cloth)
        {
            ChangeSprite(0);
            OriginalSprite(1);
            OriginalSprite(2);
            OriginalSprite(3);
        }
        else if(shopPrefabSpawn.selectShop == ShopPrefabSpawn.shopType.furniture)
        {
            ChangeSprite(1);
            OriginalSprite(0);
            OriginalSprite(2);
            OriginalSprite(3);
        }
        else if (shopPrefabSpawn.selectShop == ShopPrefabSpawn.shopType.background)
        {
            ChangeSprite(2);
            OriginalSprite(1);
            OriginalSprite(0);
            OriginalSprite(3);
        }
        else if (shopPrefabSpawn.selectShop == ShopPrefabSpawn.shopType.pet)
        {
            ChangeSprite(3);
            OriginalSprite(1);
            OriginalSprite(2);
            OriginalSprite(0);
        }
    }
    private void ChangeSprite(int BtnNum)
    {
        shopTypeBtn[BtnNum].GetComponent<Image>().sprite = changeSprite[BtnNum];
        Vector3 buttonPosition = shopTypeBtn[BtnNum].transform.position;
        buttonPosition.y = c1;
        shopTypeBtn[BtnNum].transform.position = buttonPosition;
        Vector3 buttonScale = shopTypeBtn[BtnNum].transform.localScale;
        buttonScale.y = c2;
        shopTypeBtn[BtnNum].transform.localScale = buttonScale;
    }
    private void OriginalSprite(int BtnNum)
    {
        shopTypeBtn[BtnNum].GetComponent<Image>().sprite = originalSprites[BtnNum];
        Vector3 buttonPosition = shopTypeBtn[BtnNum].transform.position;
        buttonPosition.y = o1;
        shopTypeBtn[BtnNum].transform.position = buttonPosition;
        Vector3 buttonScale = shopTypeBtn[BtnNum].transform.localScale;
        buttonScale.y = o2;
        shopTypeBtn[BtnNum].transform.localScale = buttonScale;
    }
}
