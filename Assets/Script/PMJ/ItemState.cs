using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemState : MonoBehaviour
{
    public ItemData itemData;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (itemData != null)
        {
            switch (itemData.selectedItemType)
            {
                case ItemData.itemType.background:
                    if (itemData.Activation) gameObject.SetActive(true);
                    else gameObject.SetActive(false);
                    break;

                case ItemData.itemType.furniture:
                    if (itemData.Activation) image.enabled = true;
                    else image.enabled = false;
                    break;
            }
        }

    }
}
