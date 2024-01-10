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
            //게임정지
        }
    }
    public void MenuOpen()
    {
        menuSet.SetActive(true);
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Resume()
    {
        menuBtn.SetActive(true);
        menuSet.SetActive(false);
        MenuStatic.isMenuOpen = false;
    }
    public void GoHome()
    {
        //홈으로 이동
        print("GOHOME");
    }
    public void GameEnd()
    {
        //게임종료
        print("GameExit");
    }
}
