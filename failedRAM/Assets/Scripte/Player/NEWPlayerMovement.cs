using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NEWPlayerMovement : MonoBehaviour
{
    [SerializeField] private float target_sprung_weite;
    [SerializeField] private float spieler_geschwindichkeit;
    [SerializeField] private float lauf_coldown;
    [SerializeField] private float check_size = 0.5f;
    private Vector2 moveInput;

    [SerializeField] private Transform target;
    [SerializeField] private LayerMask barriere_Layer;

    [SerializeField] private bool invert;
    [SerializeField] private bool invertanimation;
    [SerializeField] private bool deactivateRotation;
    private bool wird_knopf_benutzt = false;

    private InputSystem inputSystem;
    private Animator animator;

    private void Awake()
    {
        inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        inputSystem.Player.Enable();
        inputSystem.Player.Movement.performed += OnMovementPerformed;
        inputSystem.Player.Movement.performed += OnRotationPerformed;
        inputSystem.Player.Movement.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        inputSystem.Player.Disable();
        inputSystem.Player.Movement.performed -= OnRotationPerformed;
        inputSystem.Player.Movement.performed -= OnMovementPerformed;
        inputSystem.Player.Movement.canceled -= OnMovementCanceled;
    }

    private void Start()
    {
        target.parent = null; // Remove the player object as the parent of the moving target.
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 moveDirection = Vector3.zero; // Reset moveDirection.

        if (moveInput != Vector2.zero)
        {
            moveDirection = new Vector3(moveInput.x * target_sprung_weite, 0f, moveInput.y * target_sprung_weite);
        } 

        if (CanMove() && !wird_knopf_benutzt && moveDirection != Vector3.zero)
        {
            if (!IsObstacleInPath(moveDirection) && invert)
            {
                target.position -= moveDirection;
                wird_knopf_benutzt = true;
            }
            else if (!IsObstacleInPath(moveDirection))
            {
                target.position += moveDirection;
                wird_knopf_benutzt = true;
            }
        }
        else if (moveInput == Vector2.zero || Vector3.Distance(transform.position, target.position) <= lauf_coldown)
        {
            wird_knopf_benutzt = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, spieler_geschwindichkeit * Time.deltaTime);
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        // Disable diagonal movement
        if (Mathf.Abs(moveInput.x) > 0 && Mathf.Abs(moveInput.y) > 0)
        {
            moveInput = Vector2.zero;
        }
        PlayAnimation("dodash");
    }

    private void OnMovementCanceled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }

    private bool CanMove()
    {
        return Vector3.Distance(transform.position, target.position) <= lauf_coldown;
    }

    private bool IsObstacleInPath(Vector3 direction)
    {
        if (invert)
        {
            return Physics.CheckSphere(target.position - direction, check_size, barriere_Layer);
        }
        else
        {
            return Physics.CheckSphere(target.position + direction, check_size, barriere_Layer);
        }
    }

    private void OnRotationPerformed(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();

        if ((direction != Vector2.zero)&&(invertanimation) && !deactivateRotation)
        {
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            // Negate the direction.y to invert the rotation
            transform.rotation = Quaternion.Euler(0f, Mathf.Atan2(-direction.x, -direction.y) * Mathf.Rad2Deg, 0f);

        }
        else if(direction != Vector2.zero && !deactivateRotation)
        {
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

    private void PlayAnimation(string triggerName)
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }
    }



}