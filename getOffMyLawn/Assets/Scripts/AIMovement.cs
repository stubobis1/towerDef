﻿using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;

public class AIMovement : MonoBehaviour, IKillable, IHasWaypoints
{
    public WaypointHandler Waypoints { get; set; }
    private int targetIndex = 0;


    public float Speed = 0.2f;
    // Start is called before the first frame update
    public Waypoint[] Targets;
    private Rigidbody body;
    void Start()
    {
        print("Start AI");
        Targets = Waypoints.Waypoints;
        body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }

    public void HitTrigger(Waypoint other)
    {
        //if (other == Targets[targetIndex]) {
            if (targetIndex + 1 >= Targets.Length)
            {
                print("AI Hit last Trigger, calling death");
                Destroy(this.gameObject);
                GameManager.Instance.EnemyGotThrough(this.gameObject);
            }

            else
            {
                targetIndex++;
            }

        //}
    }

    private void FixedUpdate()
    {
        transform.LookAt(Targets[targetIndex].transform);
        body.AddForce(transform.forward * Speed,ForceMode.VelocityChange);
        //body.velocity = Vector3.Lerp(body.velocity,transform.forward * Speed, Acceleration); 
    }
}
