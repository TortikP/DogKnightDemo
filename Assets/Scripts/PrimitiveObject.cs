using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveObject : MonoBehaviour
{
    [SerializeField] public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canvas.transform.localPosition = new Vector3(0, 5, 0);
        canvas.transform.LookAt(FindObjectOfType<Camera>().transform.position);
    }
}
