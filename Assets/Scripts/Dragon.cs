using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Entity
{
    public Transform spine;
    private bool isGround;
    private bool isFlying;
    private bool isMounted;
    DogKnight player;
    public void OnMouseDown()
    {
        
        player.transform.parent = spine;
        player.transform.localPosition = new Vector3(0, 1.5f, 0);
        player.transform.localRotation = Quaternion.Euler(-26, -90, 0);
        player.IsOnDragon = true;
        isMounted = true;
    }
    protected override void Start()
    {
        base.Start();
        player = FindObjectOfType<DogKnight>();
    }
    public void Update()
    {
        if (isMounted)
        {
            Movement();
            Dismount();
        }
    }
    public void Movement()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Transform dragon = transform;
        if (vertical != 0 || horizontal != 0)
        {

            Vector3 movementDirection = new Vector3(0, 0, vertical);
            movementDirection = Quaternion.AngleAxis(player.cameraPoint.rotation.eulerAngles.y, Vector3.up) * movementDirection;
            dragon.GetComponent<Rigidbody>().velocity = movementDirection * speed + transform.up * rigidbody.velocity.y + horizontal * speed * transform.right;
            if (vertical != 0)
            {
                dragon.rotation = Quaternion.Lerp(dragon.rotation, Quaternion.AngleAxis(player.cameraPoint.rotation.eulerAngles.y, Vector3.up), 0.1f);
            }
            animator.SetFloat("speed", System.Math.Abs(dragon.GetComponent<Rigidbody>().velocity.x) + System.Math.Abs(dragon.GetComponent<Rigidbody>().velocity.z));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dragon.GetComponent<Rigidbody>().velocity = dragon.up * speed;
            isFlying = true;
            animator.SetBool("floor", false);
            animator.SetTrigger("fly");
            dragon.GetComponent<Rigidbody>().drag = 1;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            dragon.GetComponent<Rigidbody>().velocity = dragon.up * -speed;
        }
    }
    public void Dismount()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            player.transform.parent = null;
            player.IsOnDragon = false;
            isMounted = false;
            rigidbody.velocity = Vector3.zero;
            animator.SetFloat("speed", System.Math.Abs(rigidbody.velocity.x) + System.Math.Abs(rigidbody.velocity.z));
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGround = true;
            isFlying = false;
            animator.SetBool("floor", true);
            GetComponent<Rigidbody>().drag = 0;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGround = false;
            if (isFlying)
            {
                print("fly!");
                animator.SetBool("floor", false);
            }
        }

    }
}
