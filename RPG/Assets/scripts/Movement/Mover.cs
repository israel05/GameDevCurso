using RPG.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {

        [SerializeField] Transform target;
        NavMeshAgent navMeshAgent;





        void Update()
        {
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity); 
            // De velocidad Global a local
            // la velocidad velocity usa las coordenadas globales, dentro del mundo y yo necesito las locales
            // con respecto a mi jugador, conm respecto a local la convierto en INverseTransformDirection
            float speed = localVelocity.z; //la velocidad hacia adelante
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
        public void Start()
        {
            
            navMeshAgent = GetComponent<NavMeshAgent>();
        }



        public void Cancel()//implementado por usar el interfaz IAction
        {
            navMeshAgent.isStopped = true;
        }


        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this); //llamo a startaction para que sepa que soy yo quien lo llama          

            MoveTo(destination);
        }


        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
            navMeshAgent.isStopped = false;    
        }

      

    }

}

