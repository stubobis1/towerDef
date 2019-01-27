using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointHandler : MonoBehaviour
{
    public static WaypointHandler instance;
    public Waypoint[] Waypoints;

    public WaypointHandler()
    {
        instance = this;
    }

    private void Start()
    {
        Waypoints = GetComponentsInChildren<Waypoint>();
    }
}
