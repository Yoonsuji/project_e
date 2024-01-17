using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int playerLife = 3;
    public GameDirector gameDirector;
    // Start is called before the first frame update
    void Start()
    {
        this.gameDirector.Init(this.playerLife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
