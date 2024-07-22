using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    GameObject player;
    public Item coin;
    public float attackRadius = 1f;
    public float attackCooldown = 1f;
    private bool canAttack = true;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        player = FindObjectOfType<DogKnight>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Dead)
        {
            Vector3 target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(target);
            if (Vector3.Distance(transform.position, target) > attackRadius)
            {
                animator.SetBool("attack", false);
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            }
            else
            {
                if (canAttack)
                {
                    animator.SetBool("attack", true);
                    Attack();
                    StartCoroutine(ReachargeAttack(attackCooldown));
                }
            }
        }
    }

    public override void Die()
    {
        Instantiate(coin.prefab, transform.position, Quaternion.identity);
        base.Die();
    }
    IEnumerator ReachargeAttack(float attackCooldown)
    {
        yield return new WaitForEndOfFrame();
        canAttack = false;
        animator.SetBool("attack", false);
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
