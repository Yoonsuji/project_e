using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public Heart heartController1;
    public Heart heartController2;
    public Heart heartController3;
    public static int hp = 3;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject GameOverPannel;
    // Start is called before the first frame update
    void Start()
    {
        life1.GetComponent<Image>().enabled = true;
        life2.GetComponent<Image>().enabled = true;
        life3.GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch(hp)
        {
            case 2:
                heartController1.PlayHeartAni();
                Invoke("Delect", 0.25f);
                break;
            case 1:
                heartController2.PlayHeartAni();
                Invoke("Delect2", 0.25f);
                break;
            case 0:
                heartController3.PlayHeartAni();
                Invoke("Delect3", 0.25f);
                Invoke("GameOver", 1f);
                break;
        }

    }
    void Delect()
    {
        life3.GetComponent<Image>().enabled = false;
    }
    void Delect2()
    {
        life2.GetComponent<Image>().enabled = false;
    }
    void Delect3()
    {
        life1.GetComponent<Image>().enabled = false;
    }
    void GameOver()
    {
        GameOverPannel.SetActive(true);
    }
    public void Restarthp()
    {
        hp = 3;
        life1.GetComponent<Image>().enabled = true;
        life2.GetComponent<Image>().enabled = true;
        life3.GetComponent<Image>().enabled = true;
        GameOverPannel.SetActive(false);
    }
}
