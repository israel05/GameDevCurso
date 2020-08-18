using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat{

    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;
      
        private bool isDead;

        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }



        public void TakeDamage(float damage)
        {
            if (!IsDead)
            {
                health = Mathf.Max(health - damage, 0);
                print("Enemigo con vida: " + health);
            }
           
            if (health <= 0 && !IsDead) 
            {
                IsDead = true;           
                GetComponent<Animator>().SetTrigger("die");
                
                
            }            
        }
    }
}
