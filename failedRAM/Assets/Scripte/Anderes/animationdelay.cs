using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedAnimation : MonoBehaviour
{
    [SerializeField]
    private float delay = 2f;  // Set the default delay in seconds

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("StartAnimation", delay);
    }

    void StartAnimation()
    {
        Debug.Log("Setting StartAnimation boolean parameter.");
        if (animator != null && gameObject.activeInHierarchy)
        {
            animator.SetBool("IsStartAnimation", true);  // Replace with your boolean parameter name
        }
        else
        {
            Debug.LogError("Animator is null or object is not active. Make sure the script is attached to a GameObject with an Animator component.");
        }
    }

}
