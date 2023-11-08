using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelSelectionUndRestartLogic : MonoBehaviour
{
    private InputSystem inputSystem;
    private GameManager gameManager;

    private void Awake()
    {
        inputSystem = new InputSystem();

        // If the GameManager component is not found, add one to the GameObject
        gameManager = gameObject.GetComponent<GameManager>();        
    }

    private void OnEnable()
    {
        inputSystem.Menu.Enable();
        inputSystem.Menu.OpenLevelSelect.performed += LevelSelectPerformed;
        inputSystem.Menu.RestartLevel.performed += RestartPerformed;    
    }
    private void OnDisable()
    {
        inputSystem.Menu.Disable();
        inputSystem.Menu.OpenLevelSelect.performed -= LevelSelectPerformed;
        inputSystem.Menu.RestartLevel.performed -= RestartPerformed;
    }

    private void LevelSelectPerformed(InputAction.CallbackContext context)
    {
        gameManager.ReturnToLevelSelect();
    }
    private void RestartPerformed(InputAction.CallbackContext context)
    {
        gameManager.RestartLevel();
    }
}
