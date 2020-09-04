using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;
using UnityEngine.Video;

namespace RPG.Core{

    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float health = 100f;
      
        private bool isDead;

        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }

        public object CaptureState()
        {
            return health;
        }

        public void RestoreState(object state)
        {
           //casting
            this.health = (float)state;

            if (health < 0)
            {
                IsDead == true;
            }
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
                GetComponent<ActionScheduler>().CancelCurrentAction(); //  ya no puedes hacer nada mas           
                
            }            
        }
    }
}
