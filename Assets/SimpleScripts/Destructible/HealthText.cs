using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleScripts
{
    public class HealthText : MonoBehaviour
    {
        [SerializeField] private Health health;
        [SerializeField] private Text text;

        private void Start()
        {
            health.ChangeHitPoints.AddListener(OnChangeHitPoints);
        }

        private void OnDestroy()
        {
            health.ChangeHitPoints.RemoveListener(OnChangeHitPoints);
        }

        private void OnChangeHitPoints()
        {
            text.text = health.GetHitPoints().ToString();
        }
    }
}

