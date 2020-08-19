using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        private void Update()
        {
            GameObject player = GameObject.FindWithTag("Player");
          

            float distanciaActual =    Vector3.Distance(transform.position, player.transform.position);
            if( distanciaActual < chaseDistance)
            {
                print("Te veeeeeoooo" + name);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }

    }

}
