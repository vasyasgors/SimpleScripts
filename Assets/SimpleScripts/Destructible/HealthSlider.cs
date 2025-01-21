using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleScripts
{
    public class HealthSlider : MonoBehaviour
    {
        [SerializeField] private Health health;
        [SerializeField] private Image image;

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
            image.fillAmount = (float)health.GetHitPoints() / (float)health.GetMaxHitPoints();
        }
    }
}
