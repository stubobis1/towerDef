﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void EnemyGotThrough(GameObject enemy)
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
