using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    public Vector3 start_position;
    public Transform target;

    public float target_sprung_weite;    
    public float lauf_coldown;
    public float gewollteZeitDauer;
    public AnimationCurve curve;
    private float vergangene_Zeit;

    private void Start()
    {
        target.parent = null;    
        start_position = transform.position;

    }

    private void Update()
    {     

        //Bewegung
        vergangene_Zeit += Time.deltaTime;
        float percentageComplete = vergangene_Zeit / gewollteZeitDauer;
        transform.position = Vector3.Lerp(start_position, target.position, curve.Evaluate(percentageComplete));
        //Coldown
        if (Vector3.Distance(transform.position, target.position) <= lauf_coldown)
        {
            //Input
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {                start_position = transform.position;

                target.position += new Vector3(Input.GetAxisRaw("Horizontal")*target_sprung_weite, 0f, 0f);

            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {                start_position = transform.position;

                target.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical")*target_sprung_weite);

            }
        }
    }
}
