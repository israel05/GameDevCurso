using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;
using System;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float weaponDamage = 2f;
        [SerializeField]   float timeBetweenAttacks = 1f;
        [SerializeField] Weapon weapon = null;
        [SerializeField] Transform handTransfor = null;

        float timeSinceLastAttack = Mathf.Infinity; 
        Health target;


        private void Start()
        {
            SpawnWeapon();
        }

     

        public void Update()
        {
            timeSinceLastAttack += Time.deltaTime; //desde la ultima vez que se actualizo el fotograma
            
            if (target == null) return;
            if (target.IsDead) return; //si ya esta muerto...

            if (!GetIsInRange()) // sacamos esta funcion y asi no da excepción al poder tener un target null
                // la trampa esta en que al dar la primera parte del if falso, no entra en la parte de calcular GetIsInRange que nos daria
                // fallo por tener un target null
            {
                GetComponent<Mover>().MoveTo(target.transform.position, 1f); //maxi velocidad de ataque
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

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) return false;
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead;
       
        }
      

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this); //llamo a startaction para que sepa que soy yo quien lo llama
            
            target = combatTarget.GetComponent<Health>();
        }


          private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
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
            GetComponent<Mover>().Cancel();
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }

        private void SpawnWeapon()
        {
            if (weapon == null) return;

            Animator animator = GetComponent<Animator>();
            weapon.Spawn(handTransfor, animator);
        }


    }

}
