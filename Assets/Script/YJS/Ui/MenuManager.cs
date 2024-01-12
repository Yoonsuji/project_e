using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menuSet;
    public GameObject menuBtn;
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
        if (menuSet.activeSelf == true)
        {
            menuBtn.SetActive(false);
            MenuStatic.isMenuOpen = true;
            //��������
        }
    }
    public void MenuOpen()
    {
        menuSet.SetActive(true);
    }

    public void ReStart()
    {
        SceneManager.LoadScene("HeroWars_Tower");
    }

    public void Resume()
    {
        menuBtn.SetActive(true);
        menuSet.SetActive(false);
        MenuStatic.isMenuOpen = false;
    }
    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
    public void GameEnd()
    {
        Application.Quit();
    }
}
