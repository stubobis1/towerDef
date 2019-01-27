using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThrowController : MonoBehaviour
{
    public float power = 45f;
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
    }

    // Update is called once per frame
    private float timeToFireNext;
    public float cooldown;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        { 
            if (Time.time > timeToFireNext)
            {
                Fire();
                timeToFireNext = Time.time + cooldown;
            }
            else
            {
                print("COOLDOWN");
            }
        }
    }
    
    void Fire()
    {
        GameManager.Instance.scoreShotsFired++;
        SFX.Instance.source.PlayOneShot(SFX.Instance.explostionSound);
        
        var index = Random.Range(0, this.components.Count);
        var obj = Instantiate(this.components[index]);
        obj.gameObject.AddComponent<Esplosems>();
        obj.transform.position = throwPoint.position;
        obj.transform.rotation = Random.rotation;
        var rb = obj.GetComponent<Rigidbody>();
        if (!rb)
            throw new System.Exception("created obj does not have rigid body");
        rb.velocity = this.playerCam.transform.forward * this.power;
        var rotForce = 10000f * Random.value;
        rb.AddTorque(new Vector3(Random.value * rotForce, Random.value * rotForce, Random.value * rotForce));

    }
}
