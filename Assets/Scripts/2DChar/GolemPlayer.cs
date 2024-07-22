using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GolemPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public float speed;
    public float jumpForce;
    public bool isRotated = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal != 0)
        {
            if (!isRotated)
            {
                rb.velocity = horizontal * transform.right * speed + transform.up * rb.velocity.y;
            }
            else
            {
                rb.velocity = -horizontal * transform.right * speed + transform.up * rb.velocity.y;
            }
            animator.SetFloat("speed", rb.velocity.magnitude);
            if(rb.velocity.normalized.x < 0 && !isRotated)
            {
                transform.eulerAngles = new Vector3(0,180,0);
                isRotated = true;
            }
            else if(isRotated && rb.velocity.normalized.x > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRotated = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2 (0, jumpForce));
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("attack");
        }
    }
}
