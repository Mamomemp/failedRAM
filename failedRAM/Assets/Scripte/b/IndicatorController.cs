using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    public List<GameObject> targets;  // Liste von Zielen, die überwacht werden sollen
    public GameObject indicatorPlane;  // IndikatorPlatte
    public float rotationSpeed = 5f;  // Rotationsgeschwindigkeit

    void Update()
    {
        bool isTouchingTarget = false;

        // Überprüfen, ob einer der Ziele berührt wird
        foreach (GameObject target in targets)
        {
            if (GetComponent<Collider>().bounds.Intersects(target.GetComponent<Collider>().bounds))
            {
                isTouchingTarget = true;
                break;
            }
        }

        // IndikatorPlatte entsprechend drehen
        Quaternion targetRotation = isTouchingTarget ? Quaternion.Euler(indicatorPlane.transform.rotation.eulerAngles + new Vector3(0f, 180f, 0f)) : Quaternion.Euler(Vector3.zero);
        indicatorPlane.transform.rotation = Quaternion.Lerp(indicatorPlane.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
