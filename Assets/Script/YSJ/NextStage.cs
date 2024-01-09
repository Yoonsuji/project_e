using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    public GameObject Clear;
    public GameObject Clear2;
    public GameObject Stage;
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Click1to2()
    {
        Clear.SetActive(false);
        Stage.SetActive(false);
        Stage1.SetActive(false);
        Stage2.SetActive(true);
    }

    public void Click2to3()
    {
        Clear2.SetActive(false);
        Stage2.SetActive(false);
        Stage3.SetActive(true);
    }
}
