using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    // [SerializeField]
    // private float delayTime = 1f; // Die Wartezeit vor dem Anzeigen des Win Screen

    [SerializeField]
    private GameManager Gamemanager;

    private bool win = false;

    public void WinScreen_toggle()
    {
        win = true;
        ShowWinScreen(); // Call the GameManager method
        //Invoke("ShowWinScreen", delayTime);
    }

    private void ShowWinScreen()
    {
        gameObject.SetActive(true);
    }
}
