using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;


namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;

        Transform target;


        public void Update()
        {
            bool isInRange = Vector3.Distance(target.position, this.transform.position) < weaponRange;

            if (target != null && !isInRange)
            {
                GetComponent<Mover>().MoveTo(target.position);
            } 
            else
            {
                GetComponent<Mover>().Stop();// no avances más
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }
    }

}
