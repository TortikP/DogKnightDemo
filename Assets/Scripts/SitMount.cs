using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitMount : MonoBehaviour
{
    public GameObject saddle;
    protected Vector3 movementVector;
    GameObject player;
    bool isRiding = false;

    Rigidbody rb;
    Animator animator;
    public float speed = 10;

    public GameObject eggPref;
    public Transform startShoot;
    public CameraController playerCameraPoint;
    public Transform cameraPoint;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<DogKnight>().gameObject;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRiding)
        {
            Shoot();
            if (Input.GetKeyDown(KeyCode.F))
            {
                WakeUp();
            }
        }
    }

    void FixedUpdate()
    {
        if(isRiding)
        {
            Movement();
            Fly();
        }
    }

    private void LateUpdate()
    {
        rb.velocity = Vector3.zero;
    }

    private void OnMouseDown()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < 15) { 
            player.transform.position = saddle.transform.position;
            player.transform.SetParent(saddle.transform);
            player.GetComponent<DogKnight>().enabled = false;    
            player.GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<Rigidbody>().isKinematic = true;
            player.GetComponent<Collider>().enabled = false;
            player.GetComponent<DogKnight>().animator.SetFloat("speed", 0);
            player.transform.localRotation = Quaternion.Euler(-27.03f, -83.112f, 0);
            isRiding = true;
            /*playerCameraPoint.player = transform;
            playerCameraPoint.transform.SetParent(transform);
            playerCameraPoint.transform.localPosition = cameraPoint.localPosition;
            playerCameraPoint.transform.localRotation = Quaternion.Euler(20, 0, 0);*/
        }
    }

    private void WakeUp()
    {
        player.transform.SetParent(null);
        player.GetComponent<DogKnight>().enabled = true;
        player.GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<Collider>().enabled = true;
        player.transform.localRotation = Quaternion.Euler(0, 0, 0);
        isRiding = false;
        /*playerCameraPoint.player = player.transform;
        playerCameraPoint.transform.SetParent(player.transform);
        playerCameraPoint.transform.localPosition = new Vector3(0, 1.5f, -2.3f);
        playerCameraPoint.transform.localRotation = Quaternion.Euler(20, 0, 0);*/
    }

    protected void Movement()
    {
        movementVector = transform.right * Input.GetAxis("Horizontal") + playerCameraPoint.transform.forward * Input.GetAxis("Vertical");
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            rb.MovePosition(rb.position + movementVector * speed * Time.deltaTime);
            if (Input.GetAxis("Vertical") != 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(playerCameraPoint.transform.rotation.eulerAngles.y, Vector3.up), 0.5f);
            }
        }
        animator.SetFloat("speed", System.Math.Abs((movementVector * speed).z));
    }

    protected void Fly()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            movementVector = transform.up;
            rb.MovePosition(rb.position + movementVector * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            movementVector = -transform.up;
            rb.MovePosition(rb.position + movementVector * speed * Time.deltaTime);
        }
    }

    protected void Shoot()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            GameObject egg = Instantiate(eggPref, startShoot.position, transform.rotation);
            Destroy(egg, 5);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            animator.SetBool("fly", true);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            animator.SetBool("fly", false);
        }
    }
}
