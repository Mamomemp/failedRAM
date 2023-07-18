using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnContact : MonoBehaviour
{
    [SerializeField]
    private bool hasCollided = false; // Flag to track collision

    [SerializeField]
    private float rotationDuration = 0.5f; // Duration for which the object remains rotated

    private Coroutine rotationCoroutine; // Reference to the coroutine

    private void OnCollisionEnter(Collision collision)
    {
        // Check if colliding with an object with the "Indikator_aktivierer" tag and hasn't collided before
        if (!hasCollided && collision.gameObject.CompareTag("Indikator_aktivierer"))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            hasCollided = true;

            // Start the rotation timer
            rotationCoroutine = StartCoroutine(RotateBack());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if colliding with an object with the "Indikator_aktivierer" tag and hasn't collided before
        if (hasCollided && collision.gameObject.CompareTag("Indikator_aktivierer"))
        {
            transform.localRotation = Quaternion.Euler(180, 0, 0);
            hasCollided = false;

            // Stop the rotation timer if it is running
            if (rotationCoroutine != null)
                StopCoroutine(rotationCoroutine);
        }
    }

    private IEnumerator RotateBack()
    {
        yield return new WaitForSeconds(rotationDuration);

        transform.localRotation = Quaternion.Euler(180, 0, 0);
        hasCollided = false;
    }
}

