using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    void Start()
    {
        GetComponent<Light>().enabled = false;
    }
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DogKnight>())
        {
            GetComponent<Light>().enabled = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<DogKnight>())
        {
            GetComponent<Light>().enabled = false;
        }
    }
}
