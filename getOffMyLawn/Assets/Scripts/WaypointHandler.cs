﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointHandler : MonoBehaviour
{
    public Waypoint[] Waypoints;

    private void Start()
    {
        Waypoints = GetComponentsInChildren<Waypoint>();
    }
}
