using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {

        MonoBehaviour currentAction;

        public void StartAction(MonoBehaviour action) //porque tanto Fighter o Mover son Hijos de MOnoBehavior
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                print("Cancelling " + currentAction);
               

            }
            currentAction = action;

        }
    }

}
