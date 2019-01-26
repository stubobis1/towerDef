  using System;
  using System.Collections;
using System.Collections.Generic;
  using System.Linq.Expressions;
  using DefaultNamespace;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject target;

    public float lookSpeed = 0.5f;
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            var ai = AIManager.Instance.GetComponentInChildren<AIMovement>();
            target = ai != null ? ai.gameObject : null;
        }
        else
        {   
            SmoothLook(target.transform.position - transform.position);
        }
        
        /*

        Vector3 direction = target.transform.position - transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(transform.up, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, lookSpeed * Time.deltaTime);
        */

        /*Vector3 direction = target.transform.position - transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, lookSpeed * Time.time);*/
    }
    void SmoothLook(Vector3 newDirection){
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), Time.deltaTime * lookSpeed);
    }
}

