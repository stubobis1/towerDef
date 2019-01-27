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
    public Transform throwPoint;
    public AnimationCurve foo;
    // Start is called before the first frame update
    void Start()
    {
        if (!playerCam)
            this.playerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (components.Count < 1)
            throw new System.Exception("we need somthing to throw");

        if (!throwPoint)
            throwPoint = playerCam.transform;

        this.power = this.initPower; 
    }

    // Update is called once per frame
    private float timeToFireNext;
    public float cooldown;
    void FixedUpdate()
    {
            if (Input.GetButton("Fire1"))
            {
                this.power += increaseRate;
            }

        if (Time.time > timeToFireNext)
        {

            if (Input.GetButtonUp("Fire1"))
            {
                Fire();
                this.power = this.initPower;
                timeToFireNext = Time.time + cooldown;
            }
            
        }
    }
    
    void Fire()
    {
        var index = Random.Range(0, this.components.Count);
        var obj = Instantiate(this.components[index]);
        obj.transform.position = throwPoint.position;
        var rb = obj.GetComponent<Rigidbody>();
        if (!rb)
            throw new System.Exception("created obj does not have rigid body");
        //rb.AddForce(this.playerCam.transform.forward * this.power, ForceMode.Impulse);
        rb.velocity = this.playerCam.transform.forward * this.power;

    }
}
