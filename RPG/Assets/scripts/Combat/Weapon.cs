
using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make new Weapon", order= 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] AnimatorOverrideController weaponOverride = null;
        [SerializeField] GameObject weaponPrefab = null;
        public void Spawn(Transform handTrasnform, Animator animator)
        {
            Instantiate(weaponPrefab, handTrasnform);
            animator.runtimeAnimatorController = weaponOverride;
        }

    }


}


