using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleScripts
{
    public class Destructible : MonoBehaviour
    {
        [SerializeField] private int maxHitPoints;

        [SerializeField] private EventHandler died;
        [SerializeField] private EventHandler changedHitPoints;


        public UnityAction Died;
        public UnityAction ChangedHitPoints;

        private int hitPoints;

        private void Start()
        {
            hitPoints = maxHitPoints;
            changedHitPoints.ForcedInvoke();
        }

        public void ApplyDamage(int damage)
        {
            hitPoints -= damage;

            changedHitPoints.ForcedInvoke();

            if (hitPoints <= 0)
            {
                Kill();
            }
        }

        public void Kill()
        {
            hitPoints = 0;

            changedHitPoints.ForcedInvoke();
            died.ForcedInvoke();
        }

        public int GetHitPoints()
        {
            return hitPoints;
        }

        public int GetMaxHitPoints()
        {
            return maxHitPoints;
        }
    }
}
