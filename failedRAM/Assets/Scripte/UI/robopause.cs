using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Audio;
using UnityEngine.UI;

public class TimelineController : MonoBehaviour
{
    [SerializeField] private KeyCode pauseKey = KeyCode.P;
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private AudioSource audioSource;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            if (audioSource != null) audioSource.Pause();
        }
        else
        {
            Time.timeScale = 1f;
            if (audioSource != null) audioSource.UnPause();
        }
    }
}
