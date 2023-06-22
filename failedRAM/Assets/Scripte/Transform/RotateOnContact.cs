using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnContact : MonoBehaviour
{
    [SerializeField]
    private bool hasCollided = false; // Flag to track collision

    private void OnCollisionEnter(Collision collision)
    {
        // Check if colliding with an object with the "Indikator_aktivierer" tag and hasn't collided before
        if (!hasCollided && collision.gameObject.CompareTag("Indikator_aktivierer"))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            hasCollided = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if colliding with an object with the "Indikator_aktivierer" tag and hasn't collided before
        if (hasCollided && collision.gameObject.CompareTag("Indikator_aktivierer"))
        {
            transform.localRotation = Quaternion.Euler(180, 0, 0);
            hasCollided = false;
        }
    }
}

