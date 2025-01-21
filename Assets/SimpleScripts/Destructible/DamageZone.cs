using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleScripts
{
    public class DamageZone : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private float damageRate;

        private Health destructible;
        private float timer;

        private void Update()
        {
            if (destructible == null) return;

            timer += Time.deltaTime;

            if (timer >= damageRate)
            {
                if (destructible != null)
                {
                    destructible.ApplyDamage(damage);
                }

                timer = 0;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            destructible = other.GetComponent<Health>();

            timer = damageRate;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Health>() == destructible)
                destructible = null;
        }
    }
}
