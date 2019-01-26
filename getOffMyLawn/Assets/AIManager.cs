using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public int level;
    public WaypointHandler waypoints;
    public GameObject[] EnemyPrefabs; //We might want something else to do enemies instead of an array (for bosses and such)
    public float SendInterval = 3f;

    private float timeToSendNext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToSendNext)
        {
            timeToSendNext = Time.time + SendInterval;
            var pos = waypoints.Waypoints[0].transform.position;
            var ai = Instantiate(EnemyPrefabs[0], this.transform);
            ai.transform.position = pos;
            ai.GetComponent<IHasWaypoints>().Waypoints = this.waypoints;
        }
    }
}
