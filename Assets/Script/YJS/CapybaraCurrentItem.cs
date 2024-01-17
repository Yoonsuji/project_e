using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Capybara Item Data", menuName = "Scriptable Object/Capybara Item Data", order = int.MaxValue)]

public class CapybaraCurrentItem : ScriptableObject
{
    public ItemData currentCloth;
    public ItemData currentBack;
    public ItemData currentPet;
}
