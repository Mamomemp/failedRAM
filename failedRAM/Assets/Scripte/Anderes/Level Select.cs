using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private CameraLevelSelectTransition camTran;
    [SerializeField] private UnlockLevel unlockLevel;
    [SerializeField] private float waitToStart = 1f;
    private string levelSelect_Index;
    private string gewuenschte_level_Index;
    private InputSystem inputSystem;
    private Vector2 moveInput;

    #region Awake enable Method
    private void Awake()
    {
        inputSystem = new InputSystem();
        levelSelect_Index = SceneManager.GetActiveScene().name;
        gewuenschte_level_Index = unlockLevel.GetSavedSceneName();
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
        StartCoroutine(LogicOnMovement(context, waitToStart));
    }

    private IEnumerator LogicOnMovement(InputAction.CallbackContext context, float delayInSeconds)
    {
        yield return camTran.ActivateAndMoveCamera(gewuenschte_level_Index, waitToStart);
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
            return true;
        }
        else
        {
            return false;
        }
    }
}
