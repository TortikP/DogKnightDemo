using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private Animator animator;
    public Transform center;
    public Transform cameraSpot;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        player = FindObjectOfType<DogKnight>().transform;
    }

    // Update is called once per framew
    void Update()
    {
        if (Time.timeScale > 0)
        {
            transform.RotateAround(center.position, transform.right, -Input.GetAxis("Mouse Y") * speedV);
            transform.RotateAround(center.position, transform.up, Input.GetAxis("Mouse X") * speedH);
            transform.LookAt(center.position, center.transform.up);

            if (Vector3.Distance(transform.position, center.position) > 10.0f)
            {
                transform.position = Vector3.Lerp(transform.position, cameraSpot.position, 0.01f);
                
            }
            if (center.parent.GetComponent<DogKnight>().isMoving)
            {
                transform.position = Vector3.Lerp(transform.position, cameraSpot.position, 0.01f);
            }
            /*if (Vector3.Distance(transform.position, center.position) < 8.0f)
            {
                transform.position = Vector3.Lerp(transform.position, center.position, -0.01f);
            }*/
            //transform.rotation = Quaternion.Lerp(transform.rotation, center.rotation, 1);
        }

        //player.Rotate(player.up * Input.GetAxis("Mouse X") * speedH);
      
    }
}
