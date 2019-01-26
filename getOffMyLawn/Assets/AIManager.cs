using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;


public class AIManager : MonoBehaviour
{
    public static AIManager Instance;

    public bool activelySending = false;
    public WaypointHandler waypoints;
    public GameObject[] EnemiesInWave;
    public int EnemyIndex = 0;
    public float SendInterval = 3f;

    private float timeToSendNext;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (activelySending)
        {
            if (Time.time > timeToSendNext)
            {
                if (EnemyIndex + 1 <= EnemiesInWave.Length)
                {
                    timeToSendNext = Time.time + SendInterval;
                    var pos = waypoints.Waypoints[0].transform.position;
                    var ai = Instantiate(EnemiesInWave[EnemyIndex], this.transform);
                    ai.transform.position = pos;
                    ai.GetComponent<IHasWaypoints>().Waypoints = this.waypoints;
                    EnemyIndex++;
                }
                else
                {
                    GameManager.Instance.FinishedLevel();
                    
                    //reset
                    this.activelySending = false;
                    EnemyIndex = 0;
                }
            }
        }
    }
}
