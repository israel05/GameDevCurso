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

    

    public void MoveTo(Vector3  destination)
    {
        GetComponent<NavMeshAgent>().destination = destination;
    }
}
