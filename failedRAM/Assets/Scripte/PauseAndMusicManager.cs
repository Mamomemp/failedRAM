using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pausemanager : MonoBehaviour
{
    public AudioClip backgroundMusic; // Die Hintergrundmusik-Datei
    public AudioClip pauseMusic; // Die Pause-Musik-Datei
    public GameObject pausePanel; // Das UI-Panel, das während der Pause angezeigt werden soll

    private AudioSource backgroundAudioSource; // Die AudioSource-Komponente für die Hintergrundmusik
    private AudioSource pauseAudioSource; // Die AudioSource-Komponente für die Pause-Musik

    private bool isPaused = false; // Speichert den Pausierstatus

    void Start()
    {
        // Initialisiere die AudioSource-Objekte
        backgroundAudioSource = gameObject.AddComponent<AudioSource>();
        pauseAudioSource = gameObject.AddComponent<AudioSource>();

        // Konfiguriere die Hintergrundmusik
        backgroundAudioSource.clip = backgroundMusic;
        backgroundAudioSource.loop = true;
        backgroundAudioSource.Play();

        // Verstecke das Pause-Panel zu Beginn des Spiels
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
                backgroundAudioSource.UnPause(); // Fortsetzen der Hintergrundmusik
                pauseAudioSource.Stop(); // Stoppe die Pause-Musik
                pausePanel.SetActive(false); // Verstecke das Pause-Panel
                isPaused = false; // Aktualisiere den Pausierstatus
            }
            else
            {
                Time.timeScale = 0f; // Pausiere das Spiel
                backgroundAudioSource.Pause(); // Pausiere die Hintergrundmusik
                pauseAudioSource.clip = pauseMusic; // Weise die Pause-Musik zu
                pauseAudioSource.Play(); // Spiele die Pause-Musik ab
                pausePanel.SetActive(true); // Zeige das Pause-Panel an
                isPaused = true; // Aktualisiere den Pausierstatus
            }
        }
    }
}
