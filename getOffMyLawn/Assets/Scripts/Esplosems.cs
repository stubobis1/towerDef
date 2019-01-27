using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esplosems : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius = 10;
    public float power = 1000;
    public float upwardsModifier = 3;
    public int ammo = 1;

    private void Start()
    {
        if(GameManager.Instance != null)
        {
            this.power = GameManager.Instance.explosionForce;
            this.radius = GameManager.Instance.explosionRadius;
            this.upwardsModifier = GameManager.Instance.explosionUpModifier;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(ammo > 0)
        {
            ammo--;
            boom();
        }
    }

    public void boom()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, upwardsModifier);
            print("boom");

            // play sound
            var killable = hit.gameObject.GetComponent<AIMovement>();
            if ( killable != null)
            {
                // set to dead.
                Destroy(killable);
                // tally dead
                GameManager.Instance.scoreDeaths++;
            }
        }
    }
}
