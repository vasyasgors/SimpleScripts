using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleScripts
{
    public class MoveTo : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Transform target;

        public UnityEvent OnReached;
        private bool isReached = false;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (transform.position == target.position)
            {
                if (isReached == false)
                {
                    if (OnReached != null) OnReached.Invoke();
                }
            }

            isReached = transform.position == target.position;
        }
    }
}
