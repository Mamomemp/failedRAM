using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UnlockLevel unlockLevel;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private WinScreen winScreen;

    [SerializeField] private int needToWin;
    private int intToWin = 0;

    private bool gameEnded = false;

    #region Awake
    private void Awake()
    {
        if (unlockLevel == null)
        {
            unlockLevel = new UnlockLevel();
        }
    }
    #endregion

    #region win/lose methods
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
    }

    public void ReturnToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelectScene");
    }
    #endregion

    #region counting methodes
    public void counter_IntToWin()
    {
        if (intToWin >= needToWin)
        {
            unlockLevel.Unlock();
            WinGame();
        }else { intToWin++; }
    }
    #endregion
    public int getNeedToWin() {return intToWin;}
}

