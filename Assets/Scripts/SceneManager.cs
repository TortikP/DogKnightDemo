using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    bool isPaused = false;
    bool isMusicPaused = false;
    public GameObject pauseMenu;
    public TMP_Text musicButtonText;
    public Button respawn;
    AudioSource[] audioSources;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>();
    }

    public void Recover()
    {
        FindObjectOfType<DogKnight>().Recover();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
                isPaused = true;
                
            }
            else
            {
                isPaused = false;
            }
            Pause(isPaused);
        }
    }

    public void Pause(bool isPaused)
    {
        if(isPaused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
        }
    }

    public void SetVolume(float volume)
    {
        foreach(var sound in audioSources)
        {
            sound.volume = volume;
        }
    }

    public void StopPlaySound()
    {
        if (!isMusicPaused)
        {
            foreach (var sound in audioSources)
            {
                sound.Pause();
            }
            isMusicPaused = true;
            musicButtonText.text = "Включить музыку";
        }
        else
        {
            foreach (var sound in audioSources)
            {
                sound.Play();
            }
            isMusicPaused = false;
            musicButtonText.text = "Выключить музыку";
        }
    }
}
