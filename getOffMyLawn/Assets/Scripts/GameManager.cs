using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    // Start is called before the first frame update
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;

    public int Level = -1;

    public List<GameObject[]> Levels = new List<GameObject[]>(); //Each item in the array will be an array of enemies to send.

    #region Levels

    

    List<GameObject[]> GetLevels()
    {
        var l = new List<GameObject[]>(); 
        //Level 1
        l.Add( new []{
            Enemy1,
            Enemy1,
            Enemy1,
            Enemy1,
            Enemy1,
        }); 
        //Level 2
        l.Add( new []{
            Enemy1,
            Enemy2,
            Enemy2,
            Enemy1,
            Enemy2,
            Enemy1,
        }); 
        //Level 3
        l.Add( new []{
            Enemy2,
            Enemy2,
            Enemy2,
            Enemy2,
            Enemy2,
        });
        return l;
    }
    
    
    #endregion

    void Start()
    {
        Instance = this;
        this.Levels = GetLevels();
    }

    bool GameStarted = false;
    public void StartGame()
    {
        GameStarted = true;
        print("Starting Game!");
        Level = 0;
        AIManager.Instance.EnemiesInWave = Levels[0];
    }
    
    
    
    void Update()
    {
        if(!GameStarted)
            StartGame();

        if (Input.GetButtonDown("Fire1") && !AIManager.Instance.activelySending)
        {
            //start if we haven't yet.
            AIManager.Instance.activelySending = true;
        }
    }

    public void EnemyGotThrough(GameObject enemy)
    {
    }

    public void FinishedLevel()
    {
        print("Finished Level: " + Level);
        Level++;
        AIManager.Instance.EnemiesInWave = Levels[Level];
        
        
        
    }
    
    // Update is called once per frame

}
