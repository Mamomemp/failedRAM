using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GamePauseManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioClip pauseMusic;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject vendingMachine;

    private AudioSource pauseAudioSource;
    private PlayableDirector playableDirector;

    private bool isPaused = false;

    void Start()
    {
        if (backgroundAudioSource == null)
        {
            backgroundAudioSource = gameObject.AddComponent<AudioSource>();
        }

        pauseAudioSource = gameObject.AddComponent<AudioSource>();
      

        // Configure background music
        if (backgroundAudioSource.clip == null)
        {
            Debug.LogWarning("Background audio clip is not set. Please assign a clip in the inspector.");
        }
        else
        {
            backgroundAudioSource.loop = true;
            backgroundAudioSource.Play();
        }

        pauseAudioSource.loop = true;

        pausePanel.SetActive(false);
        vendingMachine.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game
            backgroundAudioSource.Pause();
            pauseAudioSource.clip = pauseMusic;
            pauseAudioSource.Play();
            pausePanel.SetActive(true);
            vendingMachine.SetActive(true);
            
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            backgroundAudioSource.UnPause();
            pauseAudioSource.Stop();
            pausePanel.SetActive(false);
            vendingMachine.SetActive(false);
           
        }
    }
}
