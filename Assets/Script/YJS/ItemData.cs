using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    public int itemNumber;//������ �׷� ID(itemType�� ������ �����)
    public string itemName;//������ �̸�
    public enum itemType//������ Ÿ��
    {
        cloth, furniture, background, pet
    }
    public itemType selectedItemType;
    public enum priceType//������ ��ȭ Ÿ��
    {
        gold, dia
    }
    public priceType selectedPriceType;
    public int itemPrice;//������ ����
    public Sprite itemSprite;//������ �̹���
    public bool isItemTake;//������ ������(true) or ���ž���(false)
    public bool Activation;//������ Ȱ��ȭ(true) or ��Ȱ��ȭ(false)
}
