using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menuSet;
    public GameObject menuBtn;
    private PlayerScript player;
    private void Start()
    {
        player = FindObjectOfType<PlayerScript>();
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
        if (menuSet.activeSelf == true)
        {
            menuBtn.SetActive(false);
            player.canMove = false;
            //게임정지
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
        player.canMove = true;
    }
    public void GoHome()
    {
        player.canMove = true;
        SceneManager.LoadScene(0);
    }
    public void GameEnd()
    {
        Application.Quit();
    }
}
