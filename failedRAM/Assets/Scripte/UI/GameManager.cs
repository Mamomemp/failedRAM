using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private WinScreen winScreen;

    [SerializeField] private int needToWin;
    private int intToWin = 0;

    private bool gameEnded = false;

    #region win/lose methoden
    public void WinGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            winScreen.WinScreen_toggle();
        }
    }

    public void LoseGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            gameOverScreen.GameOverScreen_toggle();
        }
    }
    #endregion

    #region Level load methods
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

    }

    public void ReturnToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelectScene");
        Time.timeScale = 1f;

    }
    #endregion

    #region counting methodes
    public void counter_IntToWin()
    {
        if (intToWin >= needToWin)
        {
            WinGame();
        }
        else { intToWin++; }
    }
    #endregion
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
