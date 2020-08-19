using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Control
{
    public class PatrollPathScript : MonoBehaviour
    {
        [ExecuteInEditMode]
        const float waypointGizmoRadious = 0.2f;
        private void OnDrawGizmos()
        {
            for (int i = 0; i<transform.childCount; i++)
            {
                if (i == 0)
                {
                    Gizmos.color = Color.red;
                }
                else
                {
                    Gizmos.color = Color.white;
                }
                Gizmos.DrawSphere(GetWaypoint(i), waypointGizmoRadious); ;
                if (i + 1 < transform.childCount)
                {
                    Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(i+1));
                }
            }
            Gizmos.DrawLine(GetWaypoint(0), GetWaypoint(transform.childCount-1));
            Gizmos.color = Color.red;

        }

        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
    }

}

