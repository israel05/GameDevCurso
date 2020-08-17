﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    [SerializeField] Transform target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
      
       
    }

    private void MoveToCursor()
    {

        #region Solo pruebas de region

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit); //el parametro out, se pasa y se devuelve modificado 
               
        if (hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
        #endregion
    }
}
