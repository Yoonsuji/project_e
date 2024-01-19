using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPrefabUi : MonoBehaviour
{
    public ItemPrefab itemPrefab;
    public List<Sprite> textSprite = new List<Sprite>();
    private Image thisUi;

    private void Start()
    {
        thisUi = this.GetComponent<Image>();
        for(int i = 0; i < textSprite.Count; i++)
        {
            if (textSprite[i].name == itemPrefab.itemData.itemPrice.ToString())
            {
                thisUi.sprite = textSprite[i];
            }
        }
        thisUi.SetNativeSize();
    }
}
