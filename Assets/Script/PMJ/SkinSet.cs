using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSet : MonoBehaviour
{
    public ItemData[] skinSet;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SkinCheck();
    }

    public void SkinCheck()
    {
        for(int i = 0; i < skinSet.Length; i ++)
        {
            if(skinSet[i].Activation && skinSet[i].isItemTake)
            {
                 anim.SetInteger("Skin", i);
            }
        }
    }
}
