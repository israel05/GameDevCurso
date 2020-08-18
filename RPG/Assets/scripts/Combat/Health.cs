using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat{

    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;
        bool isDead = false;
        public void TakeDamage(float damage)
        {

            if (!isDead)
            {
                health = Mathf.Max(health - damage, 0);
                print("Enemigo con vida: " + health);
            }
           
            if (health <= 0 && !isDead) 
            {
                isDead = true;           
                GetComponent<Animator>().SetTrigger("die");
            }
            
        }
    }
}
