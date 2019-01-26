using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThrowController : MonoBehaviour
{
    [SerializeField]private float power = 0f;
    public float initPower = 0f;
    public float increaseRate = 0.1f;
    public List<Component> components = new List<Component>();
    public Camera playerCam;
    // Start is called before the first frame update
    void Start()
    {
        if (!playerCam)
            this.playerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        this.power = this.initPower; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            this.power += increaseRate;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Fire();
            this.power = this.initPower;
        }
    }
    
    void Fire()
    {
        var index = Random.Range(0, this.components.Count);
        var obj = Instantiate(this.components[index]);
        var rb = obj.GetComponent<Rigidbody>();
        if (!rb)
            throw new System.Exception("created obj does not have rigid body");
        rb.AddForce(this.playerCam.transform.forward * this.power, ForceMode.Impulse);

    }
}
