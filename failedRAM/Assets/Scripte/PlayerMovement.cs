using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform target;
    public float target_speed;
    public float speed;
    public float lauf_coldown;
    public Vector3 start_position;
    private void Start()
    {
        target.parent = null;
        start_position = transform.position;
    }

    private void Update()
    {   //Bewegung
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
        //Coldown
        if (Vector3.Distance(transform.position, target.position) <= lauf_coldown)
        {
            //Input
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                target.position += new Vector3(Input.GetAxisRaw("Horizontal")*target_speed, 0f, 0f);
            }else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                target.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical")*target_speed);
            }
        }
    }
}
