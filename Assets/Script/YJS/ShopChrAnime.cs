using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ShopChrAnime : MonoBehaviour
{
    public CapybaraCurrentItem CapybaraCurrentItem;
    private void Update()
    {
        if (CapybaraCurrentItem.currentCloth != null)
        {
            this.GetComponent<Animator>().SetInteger("Skin", CapybaraCurrentItem.currentCloth.ClothNum);
        }
        else
        {
            this.GetComponent<Animator>().SetInteger("Skin", 0);
        }
    }
}
