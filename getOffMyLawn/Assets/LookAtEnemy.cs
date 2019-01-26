using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject target;
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = AIManager.Instance.GetComponentInChildren<AIMovement>().gameObject ;
        }

        this.transform.LookAt(target.transform);
    }
}
