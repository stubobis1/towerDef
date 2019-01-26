using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        var ai = other.GetComponent<AIMovement>();
        if (ai != null)
        {
            ai.HitTrigger(this);
        }
    }

}
