
using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make new Weapon", order= 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] GameObject equippedPrefab = null;
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float weaponDamage = 2f;
        public void Spawn(Transform handTrasnform, Animator animator)
        {
            if (equippedPrefab != null)
            {
                Instantiate(equippedPrefab, handTrasnform);
            }            
            if (animatorOverride != null)
            {
                animator.runtimeAnimatorController = animatorOverride;
            }
      
        }

        public float getRange()
        {
            return weaponRange;
        }

        public float getDamage()
        {
            return weaponDamage;
        }
    }


}


