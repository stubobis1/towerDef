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

    public GameObject Explosion;

    public float explosionRadius = 5;
    public float explosionForce = 10;
    public float explosionUpModifier = 3;

    public int scoreDeaths = 0;
    public int scoreDoorPoint = 0;
    public int scoreShotsFired = 0;

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
            getArrayOfUnit(Enemy1, 2)
        )); 

        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy2, 4)
        )); 

        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy1, 8)
        )); 

        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy2, 16)
        )); 

        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy1, 30)
        )); 
        //1:00
        l.Add(new Wave(
            10f, 
            getArrayOfUnit(Enemy2, 40)
        ));

        l.Add(new Wave(
            5f,
            getArrayOfUnit(Enemy1, 25)
        ));
        l.Add(new Wave(
            1f,
            getArrayOfUnit(Enemy2, 25)
        ));
        l.Add(new Wave(
            4f, 
            getArrayOfUnit(Enemy1, 25)
        )); 

        l.Add(new Wave(
            5f,
            getArrayOfUnit(Enemy1, 40)
        ));
        l.Add(new Wave(
            5f, 
            getArrayOfUnit(Enemy1, 40)
        )); 

        l.Add(new Wave(
            5f,
            getArrayOfUnit(Enemy1, 40)
        ));
        l.Add(new Wave(
            5f, 
            getArrayOfUnit(Enemy1, 40)
        )); 

        l.Add(new Wave(
            2f,
            getArrayOfUnit(Enemy1, 40)
        ));
        l.Add(new Wave(
            2f,
            getArrayOfUnit(Enemy1, 40)
        ));
        l.Add(new Wave(
            1f,
            getArrayOfUnit(Enemy1, 40)
        ));
        l.Add(new Wave(
            5f, 
            getArrayOfUnit(Enemy1, 40)
        )); 
        //1:50 
        l.Add(new Wave(
            5f,
            getArrayOfUnit(Enemy1, 25)
        ));
        l.Add(new Wave(
            5f, 
            getArrayOfUnit(Enemy1, 25)
        ));  
        
      

        
        
        return l;
    }
    
    
    #endregion

    public float maxCash;
    public float currentCash;
    public float cashGainSpeed;
    public float cashPerShot;
    public float cashPerLoss;

    public bool hasMoneyToFire;

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
        currentCash += cashGainSpeed * Time.deltaTime;

        hasMoneyToFire = (currentCash > cashPerShot); 
        

        HUD.Instance.PrecentageOfMoney = currentCash / maxCash;
    }

    public void EnemyGotThrough(GameObject enemy)
    {
        currentCash -= cashPerLoss;
        SFX.Instance.ChaChing();
    }

    public void Throw()
    {
        currentCash -= cashPerShot;
    }

    public void cantFire()
    {
        SFX.Instance.Nope();
    }


    // Update is called once per frame

}
