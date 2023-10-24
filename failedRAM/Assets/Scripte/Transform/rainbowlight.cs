using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowLightColorChanger : MonoBehaviour
{
    public float colorChangeSpeed = 1.0f; // Geschwindigkeit der Farbänderung
    private Light pointLight; // Referenz auf die Lichtkomponente

    private void Start()
    {
        pointLight = GetComponent<Light>();
    }

    private void Update()
    {
        // Ändern Sie die Farbe des Lichts basierend auf der Zeit
        float hue = (Time.time * colorChangeSpeed) % 1; // Berechnung des Farbwerts basierend auf der Zeit
        Color color = Color.HSVToRGB(hue, 1, 1); // Umwandlung des HSV-Farbwerts in RGB

        // Setzen Sie die Farbe der Lichtquelle auf die berechnete Farbe
        pointLight.color = color;
    }
}
