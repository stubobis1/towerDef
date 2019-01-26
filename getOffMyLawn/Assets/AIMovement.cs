using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private int targetIndex = 0;


    public float Speed = 1f;
    public float Acceleration = 1f;
    // Start is called before the first frame update
    public WaypointHandler Waypoints;
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

    public void HitTrigger(Waypoint other)
    {
        //if (other == Targets[targetIndex]) {
            if (targetIndex + 1 >= Targets.Length)
            {
                print("THISNHISXNINFS");
                GameManager.Instance.EnemyGotThrough(this.gameObject);
                Destroy(this.gameObject);
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
        body.velocity = Vector3.Lerp(body.velocity,transform.forward * Speed, Acceleration); 
    }
}
