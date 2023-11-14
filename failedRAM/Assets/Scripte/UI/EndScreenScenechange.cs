using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EndScreenScenechange : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bool isMainMenu;

    private InputSystem inputSystem;

    #region InputStuff
    private void Awake()
    {
        inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        inputSystem.Menu.Enable();
        inputSystem.Menu.Horizontal.performed += RestartLevelPerformed;
        if (!isMainMenu)
        {
            inputSystem.Menu.Vertical.performed += ReturnLevelSelectPerformed;
        }
        else
        {
            inputSystem.Menu.Vertical.performed += GoToLevelSelectPerformed;
        }
    }
    private void OnDisable()
    {
        inputSystem.Menu.Disable();
        inputSystem.Menu.Horizontal.performed -= RestartLevelPerformed;
        if (!isMainMenu)
        {
            inputSystem.Menu.Vertical.performed -= ReturnLevelSelectPerformed;
        }
        else
        {
            inputSystem.Menu.Vertical.performed -= GoToLevelSelectPerformed;
        }
    }
    #endregion

    #region scene loading stuff
    private void RestartLevelPerformed(InputAction.CallbackContext context)
    {
        gameManager.RestartLevel();
    }

    private void GoToLevelSelectPerformed(InputAction.CallbackContext context)
    {
        gameManager.GoToLevelSelect();
    }

    private void ReturnLevelSelectPerformed(InputAction.CallbackContext context)
    {
        gameManager.ReturnToLevelSelect();
    }
    #endregion
}
