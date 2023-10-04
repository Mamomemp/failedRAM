using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWPlayerMovement : MonoBehaviour
{
    [SerializeField] private float target_sprung_weite;
    [SerializeField] private float spieler_geschwindichkeit;
    [SerializeField] private float lauf_coldown;

    [SerializeField] private LayerMask barriere_Layer;
    [SerializeField] private Transform target;

    private void Start()
    {
        target.parent = null;
        
    }

    private void Update()
    {

        //Bewegung
        transform.position = Vector3.MoveTowards(transform.position, target.position, spieler_geschwindichkeit * Time.deltaTime);

        //Cooldown 
        if (Vector3.Distance(transform.position, target.position) <= lauf_coldown)
        {
            //Positive Flanke
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f && !Physics.CheckSphere(target.position + new Vector3(Input.GetAxisRaw("Horizontal") * target_sprung_weite, 0f, 0f), .5f, barriere_Layer)) 
            {
                target.position += new Vector3(Input.GetAxisRaw("Horizontal") * target_sprung_weite, 0f, 0f);
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f && !Physics.CheckSphere(target.position + new Vector3(0f, 0f, Input.GetAxisRaw("Vertical") * target_sprung_weite), .5f, barriere_Layer))
            {
                target.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical") * target_sprung_weite);
            }
        }
    }
}
