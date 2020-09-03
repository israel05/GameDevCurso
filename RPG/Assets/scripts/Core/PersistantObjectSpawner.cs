using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace RPG.Core
{
    public class PersistantObjectSpawner : MonoBehaviour
    {
        [SerializeField] GameObject persistantObjectPrefab;

        static bool hasSpawned = false; //vieve mientras que viva la app, no depende de la clase

        private void Awake()
        {
            if (hasSpawned) return;
            SpawnPersistantObjects();
            hasSpawned = true;
        }

        private void SpawnPersistantObjects()
        {
            GameObject persistantObject = Instantiate(persistantObjectPrefab);
            DontDestroyOnLoad(persistantObject);
        }
    }

}
