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

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SendWave(GameObject[] EnemiesInWave)
    {
        foreach (var e in EnemiesInWave)
        {
            var maxpos = waypoints.Waypoints[0].GetComponent<BoxCollider>().bounds.max;
            var minpos = waypoints.Waypoints[0].GetComponent<BoxCollider>().bounds.min;
            var pos = new Vector3(
                Random.Range(minpos.x,maxpos.x),
                Random.Range(minpos.y,maxpos.y),
                Random.Range(minpos.z,maxpos.z)
            );
            var ai = Instantiate(e, this.transform);
            ai.transform.position = pos;
            ai.GetComponent<IHasWaypoints>().Waypoints = this.waypoints;
        }
    }
}
