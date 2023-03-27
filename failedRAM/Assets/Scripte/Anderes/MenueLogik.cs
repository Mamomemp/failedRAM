using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenueLogik : MonoBehaviour
{
    private bool secret_level_start = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (secret_level_start == false && Input.GetAxisRaw("Horizontal") == 0)
        {
            secret_level_start = true;
            //hier startet das level
        }
          
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           SceneManager.LoadScene("LevelSelectScene");
        }
         
    } 
}
