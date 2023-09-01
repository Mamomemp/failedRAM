using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public float delayTime = 1f; // Die Wartezeit vor dem Anzeigen des Game Over-Screen

    private bool gameOver = false;

    public void Update()
    {
        if (gameOver && Input.anyKeyDown)
        {
            // Wenn der Spieler eine Taste dr�Ekt (au�er ESC), lade die aktuelle Szene neu
            if (!Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            // Wenn der Spieler die Escape-Taste dr�Ekt, lade die Szene des Hauptmen�E
            else
            {
                SceneManager.LoadScene("LevelSelectScene");
            }
        }
    }

    public void GameOverScreen_toggle()
    {
        gameOver = true;
        // Aktiviere den Game Over-Screen nach einer kurzen Wartezeit
        Invoke("ShowGameOverScreen", delayTime);
    }

    public bool getGameOver() 
    {
        return gameOver;
    }

    private void ShowGameOverScreen()
    {
        gameObject.SetActive(true);
    }

}

