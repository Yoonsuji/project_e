using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject selectPanel;
    public GameObject sceneChangePanel;
    public int gameNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GameStart()
    {
        selectPanel.SetActive(true);
    }

    public void Exit()
    {
        selectPanel.SetActive(false);
    }

    public void GameType(int game)
    {
        //sceneChangePanel.SetActive(true);
        //gameNumber = game;
        SceneManager.LoadScene(game);
    }
    public void RingGame()
    {
        SceneManager.LoadScene(1);
    }
    public void TowerGame()
    {
        StageStatic.nowStageNum = 1;
        SceneManager.LoadScene(3);
    }

}
