using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    Slider slTimer;
    public Slider timeSlider;
    private bool isTimePaused = false;
    float fSliderBarTime;
    public GameObject GameOvercanvas;
    public GameObject Clearcanvas;

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
                GameOvercanvas.SetActive(true);
                Clearcanvas.SetActive(false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameOvercanvas.SetActive(false);
        }
    }
    public void ToggleSliderPause()
    {
        isTimePaused = !isTimePaused;
        if (isTimePaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void OnTimeSliderValueChanged()
    {
        float normalizedTime = timeSlider.value;
        Time.timeScale = normalizedTime;
        timeSlider.interactable = true;
    }

    public void PauseGame()
    {
        timeSlider.interactable = false;
    }

    public void ResumeGame()
    {
        timeSlider.interactable = true;
    }
}
