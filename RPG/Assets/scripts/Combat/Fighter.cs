using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float weaponDamage = 2f;
        [SerializeField]   float timeBetweenAttacks = 1f;

        float timeSinceLastAttack = 0;
        Transform target;


        public void Update()
        {
            timeSinceLastAttack += Time.deltaTime; //desde la ultima vez que se actualizo el fotograma
            
            if (target == null) return;

            if (!GetIsInRange()) // sacamos esta funcion y asi no da excepción al poder tener un target null
                // la trampa esta en que al dar la primera parte del if falso, no entra en la parte de calcular GetIsInRange que nos daria
                // fallo por tener un target null
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();// no avances más
                AttackBehavior();//ataca ya
            }
        }

        private void AttackBehavior()
        {
            if(timeSinceLastAttack > timeBetweenAttacks)
            {
                // se va a Hit() que es llamado por la animacion
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0f;
             
               
            }        
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(target.position, this.transform.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this); //llamo a startaction para que sepa que soy yo quien lo llama
            
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }

        /// <summary>
        /// Llamado desde la animacion
        /// </summary>
        void Hit() {
            Health healthComponent = target.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
        }
    }

}
