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

        private void Save()
        {
            GetComponent<SavingSystem>().Save(defaultSaveFile);
        }





        /// <summary>
        /// Llama al sistema de cargas
        /// </summary>

        private void Load()
        {
            GetComponent<SavingSystem>().Load(defaultSaveFile);
        }
    }


}
