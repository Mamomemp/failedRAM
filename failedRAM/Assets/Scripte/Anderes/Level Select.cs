using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float target_sprung_weite;
    [SerializeField] float spieler_geschwindichkeit;
    [SerializeField] float lauf_coldown;

    [SerializeField] LayerMask barriere_Layer;

    [SerializeField] int levelSelect_Index;
    [SerializeField] int gewuenschte_level_Index;
    
    private bool ist_Settings_offen = false;
    private void Start()
    {
        target.parent = null;
        levelSelect_Index = SceneManager.GetActiveScene().buildIndex;
        gewuenschte_level_Index = levelSelect_Index;

    }

    private void Update()
    {      
        float temp = Input.GetAxisRaw("Vertical");
        gewuenschte_level_Index += (int)Mathf.Sign(temp);
        target.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical") * target_sprung_weite);
    }
    private void Level_starten()
    {
        
    }

    private void Level_erfassen()
    {
        if (Input.GetButtonDown("Enter") == true)
        {
            if (gewuenschte_level_Index != levelSelect_Index)
            {
                SceneManager.LoadScene(gewuenschte_level_Index);
            }
            else if(gewuenschte_level_Index == levelSelect_Index && ist_Settings_offen == false)
            {
                ist_Settings_offen = true;
                //Settings
            }
        }
    }
}