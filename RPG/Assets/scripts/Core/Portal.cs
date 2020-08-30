using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.Core
{
    public class Portal : MonoBehaviour
 
    {
        [SerializeField] int siguenteEscenaACargar;
        private void OnTriggerEnter(Collider other)        
        {
            if (other.tag == "Player")
            {
              StartCoroutine(Trasition());
            }          
        }

        private IEnumerator Trasition()
        {
            DontDestroyOnLoad(gameObject); // no borro el portal que llamo a esto, es el mismo truco que usababamos para la música entre niveles
            yield return SceneManager.LoadSceneAsync(siguenteEscenaACargar);
            // Al terminar la llamada yield, la función sigue desde aquí, convervando el entorno de quién lo llamo
            print("Llamo desde el portal del anterior nivel");
            // es una manera de tener info de la primera pantalla en la segunda.
            Destroy(gameObject); //ahora que ya he temrinado de hacer el print, ya no quiero el portal original
        }
        

    }

}

