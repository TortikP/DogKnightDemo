using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogKnight : Entity
{

    private bool isGround = false;
    private bool doubleJump = false;
    public float jumpForce = 10;
    public Transform cameraPoint;
    public SceneManager canvas;
    public Transform charCenter;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    float yaw = 0.0f;
    float horizontal;
    float vertical;
    bool isDashing = false;
    bool canDash = true;
    public float dashForce;
    public float dashTime;
    public float dashCooldown;
    public bool isMoving = false;
    private bool isOnDragon = false;
    int jumps = 1;
    public bool IsOnDragon
    {
        get
        {
            return isOnDragon;
        }
        set
        {
            isOnDragon = value;
            if (isOnDragon)
            {
                animator.SetFloat("Speed", 0);
                rigidbody.isKinematic = true;
                GetComponent<Collider>().enabled = false;
            }
            else
            {
                rigidbody.isKinematic = false;
                rigidbody.AddForce(new Vector3 (0, jumpForce, 0));
                GetComponent<Collider>().enabled = true;
            }
            print(animator);
        }
    }
    protected override void Start()
    {
        base.Start();
        
    }
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (!isOnDragon)
        {
            StartCoroutine(Dash());
            Attack();
            Defend();
            Run();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }
    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        Walk();
    }
    public override void Die()
    {
        Debug.Log("Time to die");
        isDead = true;
        animator.SetBool("dead", isDead);
        Debug.Log(gameObject.name + " is dead");
        var enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies)
        {
            enemy.enabled = false;
        }
        canvas.respawn.gameObject.SetActive(true);
    }


    public void Recover()
    {
        isDead = false;
        animator.SetBool("dead", isDead);
        var enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies)
        {
            enemy.enabled = true;
        }
        Health = 100;
        canvas.respawn.gameObject.SetActive(false);
    }
    public override void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 2;
        }
    }
    protected override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            base.Attack();
            int attackAnim = Random.Range(1, 3);
            Debug.Log(attackAnim);
            if (attackAnim == 1)
            {
                animator.SetTrigger("attack 1");
            }
            else
            {
                animator.SetTrigger("attack 2");
            }
            Debug.Log("Attacked Somth");
        }
    }
    protected override void Defend()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Defending = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Defending = false;
        }
        animator.SetBool("defend", Defending);
    }
    public override void Jump()
    {
        if (isGround)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else if (jumps > 0)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        jumps--;
    }

    IEnumerator Dash()
    {
        if (Input.GetKeyDown(KeyCode.E) && canDash)
        {
            print("Dashed");
            canDash = false;
            isDashing = true;
            rigidbody.useGravity = false;
            rigidbody.velocity = transform.forward * dashForce;
            yield return new WaitForSeconds(dashTime);
            rigidbody.useGravity = true;
            rigidbody.velocity = Vector3.zero;
            isDashing = false;
            yield return new WaitForSeconds(dashCooldown);
            canDash = true;
            print("Can Dash");
        }
    }
    public override void Walk()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        if (!isOnDragon)
        {
            if (vertical != 0 || horizontal != 0)
            {
                Vector3 movementDirection = new Vector3(0, 0, vertical);
                movementDirection = Quaternion.AngleAxis(cameraPoint.rotation.eulerAngles.y, Vector3.up) * movementDirection;
                rigidbody.velocity = movementDirection * speed + transform.up * rigidbody.velocity.y + horizontal * speed * transform.right;
                if (vertical != 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(cameraPoint.rotation.eulerAngles.y, Vector3.up), 0.1f);
                }
            }
            animator.SetFloat("Speed", System.Math.Abs(rigidbody.velocity.x) + System.Math.Abs(rigidbody.velocity.z));
        }
        else
        {
            //animator.SetBool("floor", isGround);
        }
        if(rigidbody.velocity.magnitude > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumps = 1;
            isGround = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGround = false;
        }

    }

    
}
