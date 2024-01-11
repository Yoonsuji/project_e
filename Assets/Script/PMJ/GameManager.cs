using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] fruits;
    public GameObject[] stagePanel;
    public GameObject[] syrup;
    public GameObject click;
    public TextMeshProUGUI stageTxt;

    public GameObject tutorialPanel;
    public GameObject clearPanel;
    public GameObject diePanel;
    public GameObject menuPanel;

    public Transform fruit;
    public int fCount;
    public static int stage;
    public bool isCoroutine;
    Ring ring;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (instance == null) { instance = this; }
        switch (stage)
        {
            case 0:
                break;

            case 1:

            case 2:
                tutorialPanel.SetActive(false);
                stagePanel[0].SetActive(false);
                stagePanel[stage].SetActive(true);
                break;
        }
        /*
        for (int i = 0; i < fCount; i++)
        {
            for (int j = 0; j < fruits.Length; j++)
            {
                Instantiate(fruits[j], fruit);
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        stageTxt.text = "STAGE:"+ (stage+1).ToString();
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if (tutorialPanel.activeSelf)
            {
                click.SetActive(true);
                tutorialPanel.SetActive(false);
            }
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Ring"))
            {
                ring = hit.collider.gameObject.GetComponent<Ring>();
                ring.able = true;
            }

        }
    }
    public void Next()
    {
        syrup = GameObject.FindGameObjectsWithTag("Metaball_liquid");
        syrup = GameObject.FindGameObjectsWithTag("Metaball_liquid2");
        foreach (GameObject syrupObj in syrup)
        {
            if (syrupObj != null)
            {
                Destroy(syrupObj);
            }
        }
        clearPanel.SetActive(false);
        stagePanel[stage].SetActive(false);
        stage++;
        stagePanel[stage].SetActive(true);
    }

    public void OnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Stop()
    {
        Time.timeScale = 0f;
        menuPanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
    }
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    public IEnumerator FadeOut(GameObject gameObject, string collisionTag)
    {
        gameObject.SetActive(false);
        //if (collision.gameObject.CompareTag("Metaball_liquid")) syrup = GameObject.FindGameObjectsWithTag("Metaball_liquid");
        //else if (collision.gameObject.CompareTag("Metaball_liquid2")) syrup = GameObject.FindGameObjectsWithTag("Metaball_liquid2");
        syrup = GameObject.FindGameObjectsWithTag(collisionTag);
        if (!isCoroutine)
        {
            isCoroutine = true; 
            float fadeCount = 1.0f;
            while (fadeCount > 0f)
            {
                fadeCount -= 0.01f;
                yield return new WaitForSeconds(0.01f);
                for (int i = 0; i < syrup.Length; i++)
                {
                    if (syrup[i] != null)
                    {
                        SpriteRenderer renderer = syrup[i].GetComponent<SpriteRenderer>();
                        //Color color= renderer.color;
                        // color.a = fadeCount;
                        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, fadeCount);
                    }
                }
            }

            foreach (GameObject syrupObj in syrup)
            {
                if (syrupObj != null)
                {
                    Destroy(syrupObj);
                }
            }

            syrup = null;

            isCoroutine = false;
        }
        //System.Array.Clear(syrup, 0, syrup.Length);
    }
}