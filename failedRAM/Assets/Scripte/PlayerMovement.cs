using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    public Transform target;
    public float target_sprung_weite;
    public float spieler_geschwindichkeit;
    public float lauf_coldown;
    

    public LayerMask barriere_Layer;

    private void Start()
    {
        target.parent = null;    
    }

    private void Update()
    {     
        //Bewegung
        transform.position = Vector3.MoveTowards(transform.position, target.position, spieler_geschwindichkeit*Time.deltaTime);


        //Coldown
        if (Vector3.Distance(transform.position, target.position) <= lauf_coldown)
        {
            //Input
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                if (!Physics.CheckSphere(target.position + new Vector3(Input.GetAxisRaw("Horizontal") * target_sprung_weite, 0f, 0f), .5f, barriere_Layer))
                {
                    target.position += new Vector3(Input.GetAxisRaw("Horizontal") * target_sprung_weite, 0f, 0f);
                }
            }
            //Um quer movement zu stoppen muss man else if machen 
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                if (!Physics.CheckSphere(target.position + new Vector3(0f, 0f, Input.GetAxisRaw("Vertical") * target_sprung_weite), .2f, barriere_Layer))
                {
                    target.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical") * target_sprung_weite);
                }
            }
        }
    }
}
