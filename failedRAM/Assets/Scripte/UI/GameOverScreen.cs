using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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


