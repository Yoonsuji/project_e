using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ClickScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
