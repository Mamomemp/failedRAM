using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private static GameOverScreen gameOverScreen;
    [SerializeField]
    private static WinScreen winScreen;

    private bool gameEnded = false;

    // Call this method when the player wins the game
    public void WinGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            winScreen.WinScreen_toggle();
        }
    }

    // Call this method when the player loses the game
    public void LoseGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            gameOverScreen.GameOverScreen_toggle();
        }
    }

    // Restart the current level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Return to the level selection scene
    public void ReturnToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelectScene");
    }
}

