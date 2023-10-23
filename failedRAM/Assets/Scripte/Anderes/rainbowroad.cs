using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainbowroad : MonoBehaviour
{
    public float colorChangeSpeed = 1.0f; // Geschwindigkeit der Farbänderung
    private Renderer objectRenderer; // Renderer-Komponente des Objekts
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // aendern Sie die Farbe des Materials des Objekts
        float hue = (Time.time * colorChangeSpeed) % 1; // Berechnung des Farbwerts basierend auf der Zeit
        Color color = Color.HSVToRGB(hue, 1, 1); // Umwandlung des HSV-Farbwerts in RGB

        // Setzen Sie die Farbe des Materials auf die berechnete Farbe
        objectRenderer.material.color = color;
    }
}
