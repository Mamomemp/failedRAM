using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWPlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float target_sprung_weite;
    [SerializeField] private float spieler_geschwindichkeit;
    [SerializeField] private float lauf_coldown;
    [SerializeField] private LayerMask barriere_Layer;
    [SerializeField] private Boolean invert;
    private float verticalInput;
    private float horizontalInput;

    private bool wird_knopf_benutzt = false;

    private void Start()
    {
        target.parent = null; //Entfernt den Spieler-Objekt als parent das moving target.
    }

    private void Update() //Wird alle paar ticks aufgerufen.
    {
       
        horizontalInput = Input.GetAxisRaw("Horizontal"); //key stroke als variable speichern
        verticalInput = Input.GetAxisRaw("Vertical");
       

        Vector3 moveDirection = Vector3.zero; //Reseten vom moveDirection

        if (Mathf.Abs(horizontalInput) == 1 ^ Mathf.Abs(verticalInput) == 1) //Checkt ob Horizentale oder Verticale knopf gedrückt wird-    CHANGE ^ to get diagonall movement
        {
            moveDirection = new Vector3(horizontalInput * target_sprung_weite, 0f, verticalInput * target_sprung_weite); //Setzt den input richtung + den multiplikator(sprung weite) als moveDirection.
        }

        if (CanMove() && !wird_knopf_benutzt && moveDirection != Vector3.zero) //Checkt 1) Spieler entfernung zum target. 2) knopf input 3) md 0
        {
            if (!IsObstacleInPath(moveDirection)&&invert)
            {
                target.position -= moveDirection;
                wird_knopf_benutzt = true;
            }else if (!IsObstacleInPath(moveDirection))
            {
                target.position += moveDirection;
                wird_knopf_benutzt = true;
            }
        }
        else if ((Mathf.Abs(verticalInput) == 0 && Mathf.Abs(horizontalInput) == 0) || (Vector3.Distance(transform.position, target.position) <= lauf_coldown)) //Bestimmt wann der der keydruck nichtmehr als druck angesehen. 
        {
            wird_knopf_benutzt = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, spieler_geschwindichkeit * Time.deltaTime); //bewegt den Spieler zum target
    }

    private bool CanMove()
    {
        return Vector3.Distance(transform.position, target.position) <= lauf_coldown;
    }

    private bool IsObstacleInPath(Vector3 direction)
    {
        if (invert)
        {
            return Physics.CheckSphere(target.position - direction, 0.5f, barriere_Layer);
        }
        else
        {
            return Physics.CheckSphere(target.position + direction, 0.5f, barriere_Layer);
        }
    }   
}
