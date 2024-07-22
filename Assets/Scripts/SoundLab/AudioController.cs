using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(m_AudioSource.isPlaying)
            {
                m_AudioSource.Pause();
            }
            else
            {
                m_AudioSource.Play();
            }
            
        }
    }


}
