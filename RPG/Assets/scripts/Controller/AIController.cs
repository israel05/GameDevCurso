using RPG.Combat;
using RPG.Core;
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

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
        }


        private void Update()
        {
            if(health.IsDead) { return; }

           if (InAttackRangeOfPlayer() && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                fighter.Cancel();
            }
        }


        private bool InAttackRangeOfPlayer()
        {

            float distanciaActual = Vector3.Distance(transform.position, player.transform.position);            
            return distanciaActual < chaseDistance;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }

    }

}
