using RPG.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class CinematicTrigger : MonoBehaviour
    {
        bool disparadoDeAntes = false;

        private void OnTriggerEnter(Collider other)
        {
            print("Colision en cinemática");

            
            if (other.gameObject.tag == "Player")
            {
                print("Colision del jugador");
                if (!disparadoDeAntes)
                {
                    GetComponent<PlayableDirector>().Play();
                    print("Colision no reprodroducida aún");
                    disparadoDeAntes = true;
                }           
            }
            
        }


    }

}
