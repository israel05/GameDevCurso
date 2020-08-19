using RPG.Combat;
using RPG.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control 
{ 
    public class PlayerController : MonoBehaviour
    {
        void Update()
        {            
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;      
        }
                  
        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit); //el parametro out, se pasa y se devuelve modificado 
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }



        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();


                if (target == null) continue;

               if (!GetComponent<Fighter>().CanAttack(target.gameObject))
                {
                    continue; //sigue a la siguiente vuelta del bucle
                }

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target.gameObject);                    
                }
                return true;
            }
            return false; // nada de lo que habia era un tipo CombatTarget
        }
    }
}