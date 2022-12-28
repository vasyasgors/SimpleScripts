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
    }
}
