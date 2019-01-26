using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Camera m_Camera;
    private static float speed = 0.1f;
    public float maxBoutns = 4.4f;
    public float minBounds = -4.5f;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       

        float xinput = Input.GetAxis("Horizontal");
        this.transform.position = new Vector3(Mathf.Clamp((this.transform.position.x + (xinput * speed)),minBounds,maxBoutns), this.transform.position.y, this.transform.position.z);



    }
}
