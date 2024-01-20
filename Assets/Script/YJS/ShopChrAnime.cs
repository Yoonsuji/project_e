using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ShopChrAnime : MonoBehaviour
{
    public CapybaraCurrentItem CapybaraCurrentItem;
    public List<RuntimeAnimatorController> Animations = new List<RuntimeAnimatorController>();
    private void Update()
    {
        if (CapybaraCurrentItem.currentCloth != null)
        {
            //this.GetComponent<Animator>().SetInteger("Skin", CapybaraCurrentItem.currentCloth.ClothNum);
            this.GetComponent<Animator>().runtimeAnimatorController = Animations[CapybaraCurrentItem.currentCloth.ClothNum];
        }
        else
        {
            this.GetComponent<Animator>().runtimeAnimatorController = Animations[0];

            //this.GetComponent<Animator>().SetInteger("Skin", 0);
        }
    }
}
