using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LodingTime : MonoBehaviour
{
    public Slider slTimer;
    private bool isTimePaused = false;
    public string NextScene;
    // Start is called before the first frame update
    void Start()
    {
        slTimer = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTimePaused)
        {
            if (slTimer.value > 0.0f)
            {
                slTimer.value -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene(NextScene);
            }
        }
    }
}
