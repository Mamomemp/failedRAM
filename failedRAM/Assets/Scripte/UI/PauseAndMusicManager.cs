using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class pausemanager : MonoBehaviour
{
    public AudioClip backgroundMusic; 
    public AudioClip pauseMusic; 
    public GameObject pausePanel;
    public GameObject VendingMachine;

    private AudioSource backgroundAudioSource; // make it Optional
    private AudioSource pauseAudioSource; 

    private bool isPaused = false;

    private void Awake()
    {
        if (VendingMachine == null)
        {
            VendingMachine = new GameObject();
        }
    }

    void Start()
    {
        backgroundAudioSource = gameObject.AddComponent<AudioSource>(); // gleiche abfrage wie in der Awake aber mit demhier
        pauseAudioSource = gameObject.AddComponent<AudioSource>();

        // Konfiguriere die Hintergrundmusik
        backgroundAudioSource.clip = backgroundMusic;
        backgroundAudioSource.loop = true;
        pauseAudioSource.loop = true;
        backgroundAudioSource.Play();

        pausePanel.SetActive(false);
        VendingMachine.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // ersetzten mit dem new inputsystem
        {
            // Pause-Logik
            if (isPaused)
            {
                Time.timeScale = 1f; // Setze das Spiel fort
                backgroundAudioSource.UnPause(); 
                pauseAudioSource.Stop(); 
                pausePanel.SetActive(false);
                VendingMachine.SetActive(false);
                isPaused = false; 
            }
            else
            {
                Time.timeScale = 0f; // Pausiere das Spiel
                backgroundAudioSource.Pause(); 
                pauseAudioSource.clip = pauseMusic; 
                pauseAudioSource.Play(); 
                pausePanel.SetActive(true);
                VendingMachine.SetActive(true);
                isPaused = true; 
            }
        }
    }
}
