using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinScreen : MonoBehaviour
{
    public float delayTime = 1f; // Die Wartezeit vor dem Anzeigen des Win Screen

    private bool win = false;
    [SerializeField]
    GameOverScreen gameOverScreen;

    private void Start()
    {
        if (!gameOverScreen.getGameOver()) 
        {
        WinScreen_toggle();
        }
    }
    public void Update()
    {
        if (win && Input.anyKeyDown)
        {
            // Wenn der Spieler eine Taste dr�Ekt (au�er R), lade die Szene des Hauptmen�E
            if (!Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene("LevelSelectScene");
            }
            // Wenn der Spieler die R-Taste dr�Ekt, lade die aktuelle Szene neu
            else
            {            
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
