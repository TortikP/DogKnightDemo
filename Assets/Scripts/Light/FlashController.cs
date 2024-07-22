using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour
{
    public AudioClip[] flashSounds;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            if (GetComponent<Light>().enabled)
            {
                GetComponent<AudioSource>().clip = flashSounds[0];
                GetComponent<AudioSource>().Play();
                GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
            }
            else
            {
                GetComponent<AudioSource>().clip = flashSounds[1];
                GetComponent<AudioSource>().Play();
                GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
            }
        }
    }
}
