using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotateOnContact : MonoBehaviour
{
    bool isInContact = false;
    Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Indikator_aktivierer"))
        {
            isInContact = true;
            // Drehe das Objekt schlagartig um 180 Grad um die x-Achse
            transform.rotation = Quaternion.Euler(180f, 0f, 0f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Indikator_aktivierer"))
        {
            isInContact = false;
            // Setze das Objekt auf die ursprÅEgliche Ausrichtung zurÅEk
            transform.rotation = initialRotation;
        }
    }
}