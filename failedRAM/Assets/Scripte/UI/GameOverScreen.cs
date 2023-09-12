using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    // [SerializeField]
    //  private float delayTime = 1f; // Die Wartezeit vor dem Anzeigen des Game Over-Screen

    [SerializeField]
    private GameManager Gamemanager;

    private bool gameOver = false;

    public void GameOverScreen_toggle()
    {
        gameOver = true;
        Gamemanager.LoseGame(); // Call the GameManager method
        // Invoke("ShowGameOverScreen", delayTime);
    }

    private void ShowGameOverScreen()
    {
        gameObject.SetActive(true);
    }
}


