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
            

            if (target != null && !GetIsInRange()) // sacamos esta funcion y asi no da excepción al poder tener un target null
                // la trampa esta en que al dar la primera parte del if falso, no entra en la parte de calcular GetIsInRange que nos daria
                // fallo por tener un target null
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Stop();// no avances más
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(target.position, this.transform.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }

}
