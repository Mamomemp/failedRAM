using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] int levelSelect_Index;
    [SerializeField] int gewuenschte_level_Index;

   // private bool ist_Settings_offen = false; // Wip
    private InputSystem inputSystem;
    private Vector2 moveInput;

    #region Awake enable Method
    private void Awake()
    {
        inputSystem = new InputSystem();
        levelSelect_Index = SceneManager.GetActiveScene().buildIndex;
        gewuenschte_level_Index = levelSelect_Index;
    }

    private void OnEnable()
    {
        inputSystem.Player.Enable();
        inputSystem.Player.Movement.performed += OnMovementPerformed;
    }

    private void OnDisable()
    {
        inputSystem.Player.Disable();
        inputSystem.Player.Movement.performed -= OnMovementPerformed;
    }
    #endregion
    private void startLevel()
    {
        if (!(gewuenschte_level_Index == levelSelect_Index))
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
        else
        {
            print("Settings wurden noch nicht Implementiert"); // Settings Implementieren
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (moveInput.y > 1 && collision.gameObject.CompareTag("Counter"))
        {
            gewuenschte_level_Index--;
        }
        if (moveInput.y > -1 && collision.gameObject.CompareTag("Counter"))
        {
            gewuenschte_level_Index++;
        }
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (Mathf.Abs(moveInput.x) > 0)
        {
            startLevel();
        }

    }
}
