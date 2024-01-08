using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    private bool isStop = false;
    // Start is called before the first frame update // Update is called once per frame
    void Update()
    {
        if (isStop)
            return;
    }
    public void PauseGame()
    {
        isStop = true;
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        isStop = false;
        Time.timeScale = 1f;
    }

}
