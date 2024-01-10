using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PooSpwner : MonoBehaviour
{
    const float CREATE_INTERVAL = 0.18f;
    float NextCreateInterval = CREATE_INTERVAL;

    int Phase = 1;

    public GameObject Poo;
    public float CreatTime = 0;
    public float TotalTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalTime += Time.deltaTime;
        CreatTime = Time.time;
        if(CreatTime > NextCreateInterval)
        {
            CreatTime = 0;
            NextCreateInterval = CREATE_INTERVAL - (0.005f * TotalTime);
            if(NextCreateInterval < 0.005f)
            {
                NextCreateInterval = 0.005f;
            }

            for(int i = 0; i < Phase; i++)
            {
                CreatPoo(8f + i * 0.2f);
            }
        }
        if (TotalTime >= 10f)
        {
            TotalTime = 0;
            Phase++;
        }
    }

    private void CreatPoo(float y)
    {
        float x = Random.Range(-4f, 4f);
        createObject(Poo, new Vector3(x, y, 0), Quaternion.identity);
    }

    private GameObject createObject(GameObject original, Vector3 position, Quaternion rotation)
    {
        return(GameObject)Instantiate(original, position, rotation);
    }
}