using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    [SerializeField] Transform target;


    void Start()
    {
       
    }

    void Update()
    {       
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity); // De velocidad Global a local
        // la velocidad velocity usa las coordenadas globales, dentro del mundo y yo necesito las locales
        // con respecto a mi jugador, conm respecto a local la convierto en INverseTransformDirection
        float speed = localVelocity.z; //la velocidad hacia adelante
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }

    private void MoveToCursor()
    {       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit); //el parametro out, se pasa y se devuelve modificado 
               
        if (hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }      
    }
}
