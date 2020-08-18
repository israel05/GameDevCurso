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
        Health target;


        public void Update()
        {
            timeSinceLastAttack += Time.deltaTime; //desde la ultima vez que se actualizo el fotograma
            
            if (target == null) return;
            if (target.IsDead) return; //si ya esta muerto...

            if (!GetIsInRange()) // sacamos esta funcion y asi no da excepción al poder tener un target null
                // la trampa esta en que al dar la primera parte del if falso, no entra en la parte de calcular GetIsInRange que nos daria
                // fallo por tener un target null
            {
                GetComponent<Mover>().MoveTo(target.transform.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();// no avances más
                AttackBehavior();//ataca si es que cumples con canatacck
            }
        }

        private void AttackBehavior()
        {
            transform.LookAt(target.transform);
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                // se va a Hit() que es llamado por la animacion
                TriggerAttack();
                timeSinceLastAttack = 0f;
            }
        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }

        public bool CanAttack(CombatTarget combatTarget)
        {
            if (combatTarget == null) return false;
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead;
       
        }
        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this); //llamo a startaction para que sepa que soy yo quien lo llama
            
            target = combatTarget.GetComponent<Health>();
        }

        /// <summary>
        /// Llamado desde la animacion
        /// </summary>
        void Hit() {            
            target.TakeDamage(weaponDamage);
            
        }

        public void Cancel()
        {
            StopAttack();
            target = null;
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }
    }

}
