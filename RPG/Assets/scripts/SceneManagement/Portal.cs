using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using RPG.Saving;

namespace RPG.SceneManagement
{
    public class Portal : MonoBehaviour
 
    {
        enum DestinationIdentifier
        {
            A, B, C, D, E
        }


        [SerializeField] int siguenteEscenaACargar;
        [SerializeField] Transform spawnPoint;
        [SerializeField] DestinationIdentifier destination;
        [SerializeField] float fadeOutTime = 1f;
        [SerializeField] float fadeInTime = 1f;
        [SerializeField] float fadeTime = 1f;

        private void OnTriggerEnter(Collider other)        
        {
            if (other.tag == "Player")
            {
              StartCoroutine(Trasition());
            }          
        }

        private IEnumerator Trasition()
        {
            if (siguenteEscenaACargar < 0)
            {
                Debug.LogError("siguenteEscenaACargar no ajustada.");
                yield break;
            }
            DontDestroyOnLoad(gameObject); // no borro el portal que llamo a esto, es el mismo truco que usababamos para la música entre niveles
            
            Fader fader = FindObjectOfType<Fader>();

            yield return fader.FadeOut(fadeOutTime);
            //salva el nivel actual
            SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();
            wrapper.Save();
            yield return SceneManager.LoadSceneAsync(siguenteEscenaACargar);
            // Al terminar la llamada yield, la función sigue desde aquí, convervando el entorno de quién lo llamo


            //carga el nivel actual
            wrapper.Load();

            Portal otherPortal = GetOtherPortal();
            UpdatePlayer(otherPortal);
            
            yield return new WaitForSeconds(fadeTime);
            yield return fader.FadeIn(fadeInTime);
            
            // es una manera de tener info de la primera pantalla en la segunda.
            Destroy(gameObject); //ahora que ya he temrinado de hacer el print, ya no quiero el portal original
        }

        private void UpdatePlayer(Portal otherPortal)
        {
             GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<NavMeshAgent>().enabled = false;
            player.GetComponent<NavMeshAgent>().Warp(otherPortal.spawnPoint.position);           
            player.transform.rotation = otherPortal.spawnPoint.rotation;

            player.GetComponent<NavMeshAgent>().enabled = true;
        }

        private Portal GetOtherPortal()
        {            
            foreach (Portal portal in FindObjectsOfType<Portal>())
            {
                if (portal == this) continue;
                if (portal.destination != destination) continue;
                return portal;
            }
            return null;
        }
    }

}

