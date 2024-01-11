using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject selectPanel;

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

    public void EscapeRoom()
    {
        //SceneManager.LoadScene(0);
    }
    public void RingGame()
    {
        SceneManager.LoadScene(1);
    }
    public void TowerGame()
    {
        StageStatic.nowStageNum = 1;
        SceneManager.LoadScene("HeroWars_Tower");
    }
}
