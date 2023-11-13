using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenueLogik : MonoBehaviour
{
    [SerializeField] private RotateAroundPivot guyRotater;
    [SerializeField] private RotateAroundPivot movetarget;
    //[SerializeField] private BoxCollider boxcollider;
    private InputSystem inputSystem;

    #region input stuff
    private void Awake()
    {
        inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        inputSystem.Menu.Enable();
        inputSystem.Menu.Vertical.performed += weiterGehenPerformed;
    }

    private void OnDisable()
    {
        inputSystem.Menu.Disable();
        inputSystem.Menu.Vertical.performed -= weiterGehenPerformed;
    }
    #endregion 

    private void weiterGehenPerformed(InputAction.CallbackContext context)
    {
        guyRotater.enabled = true;
        movetarget.enabled = true;
       // boxcollider.enabled = false;
        StartCoroutine(LoadSceneDelayed("LevelSelectScene", 3f));
    }
    private IEnumerator LoadSceneDelayed(string sceneName, float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(sceneName);
    }
}
