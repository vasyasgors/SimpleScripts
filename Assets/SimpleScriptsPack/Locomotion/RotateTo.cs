using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleScripts
{
    public class RotateTo : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Vector3 target;

        public UnityEvent OnReached;
        private bool isReached = false;

        private void Update()
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(target), speed * Time.deltaTime);

            if(transform.localRotation == Quaternion.Euler(target))
            {
                if (isReached == false)
                {
                    if (OnReached != null) OnReached.Invoke();
                } 
            }

            isReached = transform.localRotation == Quaternion.Euler(target);
        }
    }

}
