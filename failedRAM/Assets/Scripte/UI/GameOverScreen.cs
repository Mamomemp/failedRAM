using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public void GameOverScreen_toggle()
    {
        ShowGameOverScreen();
    }

    private void ShowGameOverScreen()
    {
        gameObject.SetActive(true);
    }
}


