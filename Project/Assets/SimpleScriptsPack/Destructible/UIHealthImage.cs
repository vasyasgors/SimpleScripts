using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleScripts
{
    public class UIHealthImage : MonoBehaviour
    {
        [SerializeField] private Destructible destructible;
        [SerializeField] private Image image;

        private void Start()
        {
            destructible.ChangeHitPoints.AddListener(OnChangeHitPoints);
        }

        private void OnDestroy()
        {
            destructible.ChangeHitPoints.RemoveListener(OnChangeHitPoints);
        }

        private void OnChangeHitPoints()
        {
            image.fillAmount = (float)destructible.GetHitPoints() / (float)destructible.GetMaxHitPoints();
        }
    }
}
