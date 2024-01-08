using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] fruits;
    public GameObject[] stagePanel;
    public GameObject tutorialPanel;
    public GameObject clearPanel;
    public Transform fruit;
    public int fCount;
    public int stage;
    Ring ring;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    void Start()
    {

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
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if(tutorialPanel.activeSelf) tutorialPanel.SetActive(false);
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Ring"))
            {
                ring = hit.collider.gameObject.GetComponent<Ring>();
                ring.able = true;
            }

        }
    }
    public void Next()
    {
        clearPanel.SetActive(false);
        stagePanel[stage].SetActive(false);
        stage++;
        stagePanel[stage].SetActive(true);
    }
}