using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Collect
{
    public float damage = 5;
   
    public Rigidbody rigidbody;
    public Collider collider;
    public Collider collectCollider;
    public bool isDead;
    public bool isEquiped;
    // Start is called before the first frame update
    public override void Start()
    {
        if(condition == -1)
        {
            base.Start();
        }
        if (GetComponentInParent<Entity>())
        {
            damage += GetComponentInParent<Entity>().damage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (!isDead)
        {
            if (GetComponentInParent<Entity>())
            {
                if (other.gameObject != GetComponentInParent<Entity>().gameObject && other.GetComponent<Entity>() != null)
                {
                    if (!other.GetComponent<Entity>().Defending)
                    {
                        other.GetComponent<Entity>().TakeDamage(damage);
                    }
                    condition -= 1;
                }
            }
            else
            {
                if (other.GetComponent<Entity>())
                {
                    if (!other.GetComponent<Entity>().Defending)
                    {
                        other.GetComponent<Entity>().TakeDamage(damage);
                    }
                }
            }
        }
        else
        {
            base.OnTriggerEnter(other);
        }
    }
    public override void OnCollisionEnter(Collision collider)
    {
        base.OnCollisionEnter(collider);
        isDead = true;
    }
    public void KillSword()
    {
        isDead = true;
        rigidbody.isKinematic = false;
        collectCollider.enabled = true;
        rigidbody.AddForce(0, 100, 0);
        
    }

    public override void FixColliders()
    {
        
        collectCollider.enabled = true;
        rigidbody.isKinematic = false;
    }
}
