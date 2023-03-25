using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinScreen : MonoBehaviour
{
    public float delayTime = 1f; // Die Wartezeit vor dem Anzeigen des Win Screen

    private bool win = false;

    private void Start()
    {
        WinScreen_toggle();
    }
    public void Update()
    {
        if (win && Input.anyKeyDown)
        {
            // Wenn der Spieler eine Taste drückt (außer R), lade die Szene des Hauptmenüs
            if (!Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene("MainMenuScene");
            }
            // Wenn der Spieler die R-Taste drückt, lade die aktuelle Szene neu
            else
            {            
                SceneManager.LoadScene("LevelMenu");
            }
        }
    }

    public void WinScreen_toggle()
    {
        win = true;
        // Aktiviere den Win Screen nach einer kurzen Wartezeit
        Invoke("ShowWinScreen", delayTime);
    }

    private void ShowWinScreen()
    {
        gameObject.SetActive(true);
    }
}
