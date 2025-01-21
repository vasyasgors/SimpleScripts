using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleScripts
{
    public class Damagable : MonoBehaviour
    {
        [SerializeField] private int damage;


        public UnityEvent OnDamage;

  
        private void OnTriggerEnter(Collider other)
        {
            Health health = other.GetComponent<Health>();

            if(health == null) return;

            health.ApplyDamage(damage);
            OnDamage.Invoke();
        }

      
    }
}
