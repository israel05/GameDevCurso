using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control 
{ 

    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit); //el parametro out, se pasa y se devuelve modificado 

            if (hasHit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }
        }


        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }
    }

}