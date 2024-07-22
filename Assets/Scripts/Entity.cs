using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float health = 100;
    protected bool isDefending;
    protected bool isAttacking;
    public bool Defending
    {
        get { return isDefending; }
        set
        {
            isDefending  = value;
        }
    }
    public float Health
    {
        get { return health; }
        set { health = value;
        if(health <= 0)
            {
            }
        }
    }

    public float damage = 10;

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    protected bool isDead;
    public bool Dead { 
        get { return isDead; }
        set { isDead = value; }
    }
    public float speed = 10;
    public Animator animator;
    public Rigidbody rigidbody;
    public Collider weapon;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        GetComponentInChildren<BoxCollider>().enabled = false;
        GetComponent<Collider>().enabled = true;
        Debug.Log(GetComponentInChildren<Collider>().enabled);
    }
    public void TakeDamage(float damage)
    {
        if (!isDead)
        {
            health -= damage;
            Debug.Log(gameObject.name + ": Ouch, " + Health + " hp left");
            if (health <= 0)
            {
                Die();
            }
        }
    }
    protected virtual void Attack()
    {
        if(GetComponentInChildren<Sword>().condition <= 0)
        {
            print("Weapon broken");
            return;
        }
        
    }
    protected virtual void Defend(bool isDefending)
    {
        animator.SetBool("defend", isDefending);
    }
    protected virtual void Defend()
    {

    }
    public virtual void Walk()
    {

    }
    public virtual void Run()
    {

    }
    public virtual void Jump() {
    
    }
    public virtual void Die()
    {
        Debug.Log("Time to die");
        isDead = true;
        animator.SetBool("dead", isDead);
        GetComponentInChildren<Sword>().KillSword();
        GetComponentInChildren<Sword>().gameObject.transform.parent = null;
        Debug.Log(gameObject.name + " is dead");
        Destroy(gameObject);
    }
    public void AttackOn()
    {
        weapon.enabled = true;
        isAttacking = true;
        animator.SetBool("attack", isAttacking);
    }
    public void AttackOff()
    {
        weapon.enabled = false;
        GetComponent<Collider>().enabled = true;
        isAttacking = false;
        animator.SetBool("attack", isAttacking);
    }

}
