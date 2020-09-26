using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;
using System;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {

        const string defaultSaveFile = "Save";
        [SerializeField] float fadeInTime = 0.2f;

        IEnumerator Start()
        {
            Fader fader = FindObjectOfType<Fader>();
            fader.FadeOutInmediate();
            yield return GetComponent<SavingSystem>().LoadLastScene(defaultSaveFile);
            yield return fader.FadeIn(fadeInTime);
            

        }


        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }


            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }

        }



        /// <summary>
        /// Llmada al sistema de salvados
        /// </summary>

        public void Save()
        {
            GetComponent<SavingSystem>().Save(defaultSaveFile);
        }





        /// <summary>
        /// Llama al sistema de cargas
        /// </summary>

        public void Load()
        {
            GetComponent<SavingSystem>().Load(defaultSaveFile);
        }
    }


}
