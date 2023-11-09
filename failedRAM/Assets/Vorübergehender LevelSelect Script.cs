using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VorübergehenderLevelSelectScript : MonoBehaviour
{
    private void Update()
    {
        // Tasten 1 bis 5 überprüfen
        for (int i = 1; i <= 5; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                // Szenenindex berechnen (gehe davon aus, dass die Szenen mit Build Settings übereinstimmen)
                int sceneIndex = i - 1; // Beachte, dass in Build Settings die Szene 0 als erste Szene ist.
               
                // Szene laden
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
}
