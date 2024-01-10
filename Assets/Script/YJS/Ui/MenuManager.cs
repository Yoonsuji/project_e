using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menuSet;
    public List<GameObject> menu = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < menu.Count; i++)
        {
            menu[i].SetActive(true);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuSet.activeSelf)
            {
                Resume();
            }
            else
            {
                MenuOpen();
            }
        }
        if (menuSet.activeSelf)
        {
            //��������
        }
    }
    public void MenuOpen()
    {
        menuSet.SetActive(true);
    }

    public void Resume()
    {
        menuSet.SetActive(false);
    }
    public void GoHome()
    {
        //Ȩ���� �̵�
        print("GOHOME");
    }
    public void GameEnd()
    {
        //��������
        print("GameExit");
    }
}
