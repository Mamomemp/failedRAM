using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOn : MonoBehaviour
{
    [SerializeField]
    private bool use_Pivot;
    [SerializeField]
    private GameObject pivot_Target;
    [SerializeField]
    private int pivot_Speed;
    [SerializeField]
    private float x_RotationSpeed;
    [SerializeField]
    private float y_RotationSpeed;
    [SerializeField]
    private float z_RotationSpeed;
  

    private void Update()
    {
        if (use_Pivot == true) {
            transform.RotateAround(pivot_Target.transform.position, new Vector3(x_RotationSpeed,y_RotationSpeed,z_RotationSpeed),pivot_Speed * Time.deltaTime) ;
        }
        else {
            transform.Rotate(new Vector3(x_RotationSpeed, y_RotationSpeed, z_RotationSpeed) * Time.deltaTime);
        }
    }
}