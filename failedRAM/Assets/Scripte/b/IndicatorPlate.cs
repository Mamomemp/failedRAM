using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorPlate : MonoBehaviour
{
    public List<GameObject> emptyObjects;
 

    [SerializeField] private float xRotation;
    [SerializeField] private float yRotation;
    [SerializeField] private float zRotation;

    private Renderer renderer;
    private List<Collider> colliders;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        colliders = new List<Collider>();

        // Add all colliders from empty objects to the list
        foreach (GameObject emptyObject in emptyObjects)
        {
            colliders.Add(emptyObject.GetComponent<Collider>());
        }
    }

  /*  private void Update()
    {
        bool isVisible = false;

        // Check if any collider intersects with the indicator plate
        foreach (Collider collider in colliders)
        {
            if (collider.bounds.Intersects(renderer.bounds))
            {
                isVisible = true;
                break;
            }
        }
    }*/
}
