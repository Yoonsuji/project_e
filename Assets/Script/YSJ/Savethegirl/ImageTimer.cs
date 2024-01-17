using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageTimer : MonoBehaviour
{
    [SerializeField] private Image gauge;

    public GameObject GameOvercanvas;
    public GameObject Clearcanvas;

    private float time = 20.0f;
    private float timeSpeed = 1.0f;
    private float curTime;
    public bool isEnd;
    private void Awake()
    {
        isEnd = false;
        InitTimeSpeed(1.0f);
        StartCoroutine(OrderTimer());
    }

    IEnumerator OrderTimer()
    {
        curTime = time;
        while(curTime > 0)
        {
            curTime -= Time.deltaTime * timeSpeed;
            gauge.fillAmount = curTime / time;
            yield return null;
            if (curTime < 0)
            {
                isEnd = true;
                curTime = 0;
                TimeZero();
                yield break;
            }
        }
    }
    private void TimeZero()
    {
        GameOvercanvas.SetActive(true);
        Clearcanvas.SetActive(false);
    }
    public void InitTimeSpeed(float speed)
    {
        timeSpeed = speed;
    }
    public void PlusTime(float plus)
    {
        curTime += plus;
        if(curTime>time)
        {
            curTime = time;
        }
    }
}
