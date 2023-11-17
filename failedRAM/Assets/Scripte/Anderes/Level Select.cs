using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private CameraLevelSelectTransition camTran;
    [SerializeField] private GameManager gameManager;
    private string levelSelect_Index;
    private string gewuenschte_level_Index;

   // private bool ist_Settings_offen = false; // Wip
    private InputSystem inputSystem;
    private Vector2 moveInput;

    #region Awake enable Method
    private void Awake()
    {
        inputSystem = new InputSystem();
        levelSelect_Index = SceneManager.GetActiveScene().name;
        gewuenschte_level_Index = levelSelect_Index;
    }

    private void OnEnable()
    {
        inputSystem.Menu.Enable();
        inputSystem.Menu.Horizontal.performed += OnMovementPerformed;
    }

    private void OnDisable()
    {
        inputSystem.Menu.Disable();
        inputSystem.Menu.Horizontal.performed -= OnMovementPerformed;
    }
    #endregion
    private void startLevel()
    {
        if (NegativCheck_GIndex_With_LSIndex())
        {
          try
          {
            
                SceneManager.LoadScene(gewuenschte_level_Index);
          }
          catch (System.Exception)
           {
              print("Scene not Found");
              SceneManager.LoadScene(1);
           }
        }       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Counter"))
        {
            gewuenschte_level_Index = collision.gameObject.name;
        }
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        StartCoroutine(LogicOnMovement(context, 1f));
    }
    private IEnumerator LogicOnMovement(InputAction.CallbackContext context, float delayInSeconds)
    {
        camTran.ActivateAndMoveCamera(gewuenschte_level_Index);
        yield return new WaitForSeconds(delayInSeconds);
        if (NegativCheck_GIndex_With_LSIndex())
        {
            startLevel();
        }
    }
    private bool NegativCheck_GIndex_With_LSIndex()
    {
        if (!(gewuenschte_level_Index == levelSelect_Index))
        {
            print("Settings wurden noch nicht Implementiert"); // Settings Implementieren
            return false;
        }
        else
        {
            return true;
        }
    }

}