using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public float delayTime = 1f; // Die Wartezeit vor dem Anzeigen des Game Over-Screens

    private bool gameOver = false;

    public void Update()
    {
        if (gameOver && Input.anyKeyDown)
        {
            // Wenn der Spieler eine Taste drückt (außer ESC), lade die aktuelle Szene neu
            if (!Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            // Wenn der Spieler die Escape-Taste drückt, lade die Szene des Hauptmenüs
            else
            {
                SceneManager.LoadScene("MainMenuScene");
            }
        }
    }

    public void GameOverScreen_toggle()
    {
        gameOver = true;
        // Aktiviere den Game Over-Screen nach einer kurzen Wartezeit
        Invoke("ShowGameOverScreen", delayTime);
    }

    private void ShowGameOverScreen()
    {
        gameObject.SetActive(true);
    }
}

