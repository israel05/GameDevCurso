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
        [SerializeField] float suspecionTime = 2f;
        GameObject player;
        Fighter fighter;
        Health health;
        Vector3 guardLocation;
        Mover mover;
        float timeSinceLastSawPlayer = Mathf.Infinity; //tiempo desde que lo vi la ultima vez

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
                timeSinceLastSawPlayer = 0;
                AttackBheavior();
            }
            else if (timeSinceLastSawPlayer< suspecionTime  )
            {
                SuspicionBehavior();
            }

            else
            {
                GuardBehavior();
            }
            timeSinceLastSawPlayer += Time.deltaTime;
        }

        private void GuardBehavior()
        {
            // go back to guardLocation
            mover.StartMoveAction(guardLocation);
            //fighter.Cancel();
        }

        private void SuspicionBehavior()
        {
            print("algo malo pasa por aqui");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        private void AttackBheavior()
        {
            fighter.Attack(player);
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
