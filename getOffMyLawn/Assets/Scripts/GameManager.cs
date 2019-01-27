using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

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

    public List<Wave> HordeWaves = new List<Wave>(); //Each item in the array will be an array of enemies to send.

    public class Wave
    {
        public Wave(float t, GameObject[] e)
        {
            this.enemies = e;
            this.time = t;            
        }
    
        public float time;
        public GameObject[] enemies;
    }

    #region Horde

    GameObject[] getArrayOfUnit(GameObject o , int amount)
    {
        var go = new GameObject[amount];
        
      
        for (int i = 0; i < amount; i++)
        {
            go[i] = o;
        }
        return go;
    }


    List<Wave> GetWaves()
    {
        var l = new List<Wave>(); 

        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy1, 20)
        )); 

        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy1, 40)
        )); 

        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy1, 60)
        )); 

        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy1, 80)
        )); 

        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy1, 80)
        )); 
        //1:00
        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy1, 2)
        )); 

        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy1, 2)
        )); 

        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy1, 2)
        )); 

        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy1, 2)
        )); 

        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy1, 2)
        )); 
        //1:50 
        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy1, 2)
        )); 
        
      

        
        
        return l;
    }
    
    
    #endregion

    void Start()
    {
        Cursor.visible = false;
        Instance = this;
        this.HordeWaves = GetWaves();
    }

    bool GameStarted = false;
    public void StartGame()
    {
        GameStarted = true;
        print("Starting Game!");
    }


    private int indexofHorde;
    private float nextWaveTime;
    void Update()
    {
        if(!GameStarted)
            StartGame();

        if (Time.time > nextWaveTime)
        {
            AIManager.Instance.SendWave(HordeWaves[indexofHorde].enemies);
            nextWaveTime = Time.time + HordeWaves[indexofHorde].time;
            indexofHorde++;
        }
    }

    public void EnemyGotThrough(GameObject enemy)
    {
    }

    
    // Update is called once per frame

}
