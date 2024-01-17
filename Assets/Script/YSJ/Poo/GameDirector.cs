using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public GameObject[] lifes;
    // Start is called before the first frame update
    public void Init(int playerLife)
    {
        for (int i = 0; i < lifes.Length; i++)
            this.lifes[i].SetActive(true);
    }
}
