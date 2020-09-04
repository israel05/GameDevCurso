using RPG.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Saving;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction, ISaveable
    {

        [SerializeField] Transform target;
        [SerializeField] float maxSpeed = 6;
        

        NavMeshAgent navMeshAgent;
        Health health;


        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }

        void Update()
        {
            navMeshAgent.enabled = !health.IsDead; //si no esta muerto su meshagent funcionara
            navMeshAgent = GetComponent<NavMeshAgent>();
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
        



        public void Cancel()//implementado por usar el interfaz IAction
        {
            navMeshAgent.isStopped = true;
        }


        public void StartMoveAction(Vector3 destination, float speedFraction)
        {
            GetComponent<ActionScheduler>().StartAction(this); //llamo a startaction para que sepa que soy yo quien lo llama          
            MoveTo(destination, speedFraction);
        }


        public void MoveTo(Vector3 destination, float speedFraction)
        {
            GetComponent<NavMeshAgent>().destination = destination;
            navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
            navMeshAgent.isStopped = false;    
        }

        public object CaptureState()
        {
            return new SerializableVector3(transform.position);
        }

        public void RestoreState(object state)
        {
            SerializableVector3 x =  (SerializableVector3)state;
            GetComponent<NavMeshAgent>().enabled = false;
                this.transform.position = x.ToVector();
            GetComponent<NavMeshAgent>().enabled = enabled;
        }
    }

}

