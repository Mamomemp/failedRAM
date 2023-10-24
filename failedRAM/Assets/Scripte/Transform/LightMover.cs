using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f; // Geschwindigkeit der Bewegung
    [SerializeField] private float distance = 5.0f; // Distanz, die zuruckgelegt werden soll

    private Vector3 originalPosition; // Ausgangsposition der Lichtquelle
    private float direction = 1.0f; // Richtung der Bewegung (1.0 für vorwarts, -1.0 für ruckwarts)

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        // Bewegen der Lichtquelle entlang der X-Achse
        Vector3 newPosition = transform.position;
        newPosition.x = originalPosition.x + direction * Mathf.PingPong(Time.time * moveSpeed, distance);
        transform.position = newPosition;
    }
}
