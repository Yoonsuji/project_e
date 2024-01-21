using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public StagePrefab stagePrefab;
    public GameObject[] fruits;
    public GameObject[] stagePanel;
    public GameObject[] syrup;
    public GameObject click;
    public TextMeshProUGUI stageTxt;


    public Transform fruit;
    public int fCount;
    public static int maxStage;
    public static int stage;
    public bool isCoroutine;
    Ring ring;

    [Header ("Panel")]
    public GameObject tutorialPanel;
    public GameObject clearPanel;
    public GameObject diePanel;
    public GameObject menuPanel;

    [Header("Sound")]
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Sfx { Clear, Over, Walk, Down, PDie, EDie, PDDIe, Click};
    int sfxCursor;

    private void Awake()
    {
        maxStage = stagePanel.Length;
        stage = stagePrefab.currentStage -1;
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
        //if (Input.GetMouseButtonDown(0)) SfxPlayer(Sfx.Click);
        stagePrefab.currentStage = stage + 1;
        stageTxt.text = "STAGE:"+ (stage+1).ToString();
        if (Input.GetMouseButtonDown(0))
        {
            SfxPlayer(Sfx.Click);
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if (tutorialPanel.activeSelf)
            {
                click.SetActive(true);
                tutorialPanel.SetActive(false);
            }
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Ring") && !tutorialPanel.activeSelf)
            {
                ring = hit.collider.gameObject.GetComponent<Ring>();
                ring.able = true;
            }

        }
    }

    public void SfxPlayer(Sfx type)
    {
        int i = -1;
        
        switch (type)
        {
            case Sfx.Walk:
                sfxPlayer[0].clip = sfxClip[0];
                i = 0;
                break;

            case Sfx.Down:
                sfxPlayer[0].clip = sfxClip[1];
                i = 0;
                break;

            case Sfx.PDie:
                sfxPlayer[0].clip = sfxClip[2];
                i = 0;
                break;

            case Sfx.PDDIe:
                sfxPlayer[1].clip = sfxClip[3];
                i = 1;
                break;

            case Sfx.EDie:
                sfxPlayer[1].clip = sfxClip[4];
                i = 1;
                break;

            case Sfx.Clear:
                
                sfxPlayer[2].clip = sfxClip[5];
                //sfxPlayer[2].PlayOneShot(sfxClip[5]);
                //return;
                i = 2;
                break;

            case Sfx.Over:
                sfxPlayer[2].clip = sfxClip[6];
                i = 2;
                break;

            case Sfx.Click:
                sfxPlayer[3].clip = sfxClip[7];
                i = 3;
                break;
        }
        // sfxPlayer[sfxCursor].PlayOneShot(sfxPlayer[sfxCursor].clip);
        //Debug.Log("play"  + sfxCursor);
        if (!sfxPlayer[i].isPlaying)
        {
            sfxPlayer[i].Play();
        }
        
       // sfxCursor = (sfxCursor + 1) % sfxPlayer.Length;
       // Debug.Log(sfxCursor);
    }
  /*  IEnumerator PlaySfx(AudioClip audio)
    {
        yield return null;
        sfxPlayer[sfxCursor];
    }*/
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
        if (stage == 2) SceneManager.LoadScene(0);
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
        SceneManager.LoadScene(0);
    }

    public IEnumerator FadeOut(GameObject gameObject, string collisionTag)
    {
        //if (gameObject.name == "MP") gameObject.SetActive(false);
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

        //if (gameObject.name == "Boss") yield return new WaitForSeconds(2.3f);
        //else if (gameObject.name == "Enemy") yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(2.3f);
        gameObject.SetActive(false);
        //System.Array.Clear(syrup, 0, syrup.Length);
    }
}