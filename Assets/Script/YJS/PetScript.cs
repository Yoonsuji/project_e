using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetScript : MonoBehaviour
{
    public CapybaraCurrentItem capybaraCurrentItem;
    public List<RuntimeAnimatorController> PetAnimeCon = new List<RuntimeAnimatorController>();
    public ItemData petData;
    private void Update()
    {
        petData = capybaraCurrentItem.currentPet;
        if (capybaraCurrentItem.currentPet == null)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = null;
            this.GetComponent<Image>().sprite = null;
            this.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
        }
        else
        {
            if (capybaraCurrentItem.currentPet.name == "Kitten")
            {
                this.GetComponent<Animator>().runtimeAnimatorController = PetAnimeCon[0];
            }
            else if (capybaraCurrentItem.currentPet.name == "Crocodile")
            {
                this.GetComponent<Animator>().runtimeAnimatorController = PetAnimeCon[1];
            }
            this.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
        }
    }
}
