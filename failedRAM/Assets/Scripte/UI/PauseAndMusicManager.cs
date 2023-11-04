using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pausemanager : MonoBehaviour
{
    public AudioClip backgroundMusic; 
    public AudioClip pauseMusic; 
    public GameObject pausePanel; 

    private AudioSource backgroundAudioSource; 
    private AudioSource pauseAudioSource; 

    private bool isPaused = false;

    void Start()
    {
        backgroundAudioSource = gameObject.AddComponent<AudioSource>();
        pauseAudioSource = gameObject.AddComponent<AudioSource>();

        // Konfiguriere die Hintergrundmusik
        backgroundAudioSource.clip = backgroundMusic;
        backgroundAudioSource.loop = true;
        backgroundAudioSource.Play();

        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Pause-Logik
            if (isPaused)
            {
                Time.timeScale = 1f; // Setze das Spiel fort
                backgroundAudioSource.UnPause(); 
                pauseAudioSource.Stop(); 
                pausePanel.SetActive(false); 
                isPaused = false; 
            }
            else
            {
                Time.timeScale = 0f; // Pausiere das Spiel
                backgroundAudioSource.Pause(); 
                pauseAudioSource.clip = pauseMusic; 
                pauseAudioSource.Play(); 
                pausePanel.SetActive(true); 
                isPaused = true; 
            }
        }
    }
}