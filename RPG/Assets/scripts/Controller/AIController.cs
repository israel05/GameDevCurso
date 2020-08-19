using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        GameObject player;
        Fighter fighter;
        Health health;
        Vector3 guardLocation;
        Mover mover;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            guardLocation = transform.position;
            mover = GetComponent<Mover>();
        }


        private void Update()
        {
            if(health.IsDead) 
            {                 
                return; 
            }

           if (InAttackRangeOfPlayer() && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                // go back to guardLocation
                mover.StartMoveAction(guardLocation);
                fighter.Cancel();
            }
        }


        private bool InAttackRangeOfPlayer()
        {
            float distanciaActual = Vector3.Distance(transform.position, player.transform.position);            
            return distanciaActual < chaseDistance;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }

    }

}
