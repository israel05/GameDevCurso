﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace RPG.Core
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
            yield return SceneManager.LoadSceneAsync(siguenteEscenaACargar);
            // Al terminar la llamada yield, la función sigue desde aquí, convervando el entorno de quién lo llamo
            Portal otherPortal = GetOtherPortal();
            UpdatePlayer(otherPortal);         


            // es una manera de tener info de la primera pantalla en la segunda.
            Destroy(gameObject); //ahora que ya he temrinado de hacer el print, ya no quiero el portal original
        }

        private void UpdatePlayer(Portal otherPortal)
        {
             GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<NavMeshAgent>().Warp(otherPortal.spawnPoint.position);           
            player.transform.rotation = otherPortal.spawnPoint.rotation;
           
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

