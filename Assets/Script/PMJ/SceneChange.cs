using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public GameObject selectPanel;
    public GameObject sceneChangePanel;
    public GameObject onchunPanel;
    public ItemData itemData;
    public int gameNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (itemData.Activation) onchunPanel.SetActive(true);
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
}
