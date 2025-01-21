using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleScripts
{
    public class MoverByPoints : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private Transform[] points;
        [SerializeField] private bool loop;

        private int currentIndex = 0;

        void Update()
        {
            if (points == null) return;

            if (currentIndex > points.Length - 1) return;

            transform.position = Vector3.MoveTowards(transform.position, points[currentIndex].position, movementSpeed * Time.deltaTime);

            if (transform.position == points[currentIndex].position)
            {
                if (currentIndex == points.Length - 1)
                {
                    if (loop == true)
                    {
                        currentIndex = 0;
                        return;
                    }
                }

                currentIndex++;
            }
        }

#if UNITY_EDITOR

        void OnDrawGizmos()
        {
            if (points == null) return;

            Gizmos.DrawSphere(points[0].position, 0.5f);

            for (int i = 1; i < points.Length; i++)
            {
                Gizmos.DrawSphere(points[i].position, 0.5f);
                Gizmos.DrawLine(points[i - 1].position, points[i].position);
            }
            
            if(loop == true)
            {
                Gizmos.DrawLine(points[0].position, points[points.Length - 1].position);
            }
        }
#endif
    }
}
