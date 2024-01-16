using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    public int itemNumber;//아이템 그룹 ID(itemType과 역할이 비슷함)
    public string itemName;//아이템 이름
    public enum itemType//아이템 타입
    {
        cloth, furniture, background, pet
    }
    public itemType selectedItemType;
    public enum priceType//아이템 재화 타입
    {
        gold, dia
    }
    public priceType selectedPriceType;
    public int itemPrice;//아이템 가격
    public Sprite itemSprite;//아이템 이미지
    public bool isItemTake;//아이템 구매함(true) or 구매안함(false)
    public bool Activation;//아이템 활성화(true) or 비활성화(false)
}
