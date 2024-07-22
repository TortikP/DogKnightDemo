using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    private bool isGround = false;
    private bool doubleJump = false;
    public GameObject cube;
    public float jumpForce = 1000;

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal") * speed, rigidbody.velocity.y, Input.GetAxis("Vertical") * speed);
        rigidbody.velocity = moveVector;
        animator.SetFloat("Speed", System.Math.Abs(rigidbody.velocity.x + rigidbody.velocity.z));
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGround || doubleJump)
            {
                rigidbody.AddForce(new Vector3(0, jumpForce, 0));
                Debug.Log(rigidbody.velocity.y);
                if (doubleJump)
                {
                    doubleJump = false;
                    Debug.Log("Двойной прыжок");

                }
                else
                {
                    Debug.Log("Прыжок");
                    doubleJump = true;
                }
            }
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGround = true;
            animator.SetBool("isJumping", false);
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGround = false;
            animator.SetBool("isJumping", true);
        }
       
    }
}
