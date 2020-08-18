using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {

        IAction currentAction;

        public void StartAction(IAction action) //porque tanto Fighter o Mover son Hijos de MOnoBehavior
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                currentAction.Cancel();
               

            }
            currentAction = action;

        }
    }

}
