using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UnlockLevel unlockLevel;
    [SerializeField] private Optional<GameOverScreen> gameOverScreen;
    [SerializeField] private Optional<WinScreen> winScreen;

    [SerializeField] private int needToWin;
    private int intToWin = 0;

    private bool gameEnded = false;

    #region win/lose methods
    public void WinGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            winScreen.Value.WinScreen_toggle();
        }
    }
    public void LoseGame()
    {   
        if (!gameEnded)
        {
            gameEnded = true;
            gameOverScreen.Value.GameOverScreen_toggle();
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
        unlockLevel.SaveCurrentSceneName();
        SceneManager.LoadScene("LevelSelectScene");
        Time.timeScale = 1f;
    }

    public void GoToLevelSelect()
    {
        unlockLevel.SaveCurrentSceneName();
        SceneManager.LoadScene("LevelSelectScene");
        Time.timeScale = 1f;
    }
    #endregion

    #region counting methodes
    public void counter_IntToWin()
    {
        if (intToWin >= needToWin)
        {
            unlockLevel.Unlock();      
            WinGame();
        }
        else { intToWin++; }
    }    
    public int getNeedToWin() {return intToWin;}
    #endregion

    #region Exit Methode
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
    #endregion
}