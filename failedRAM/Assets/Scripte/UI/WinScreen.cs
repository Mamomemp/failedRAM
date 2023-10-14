using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public void WinScreen_toggle()
    {
        ShowWinScreen();
    }

    private void ShowWinScreen()
    {
        gameObject.SetActive(true);
    }
}
