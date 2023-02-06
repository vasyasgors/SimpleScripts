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
          //  destructible.ChangedHitPoints.AddListener(OnChangeHitPoints);
        }

        private void OnDestroy()
        {
           // destructible.ChangedHitPoints.RemoveListener(OnChangeHitPoints);
        }

        private void OnChangeHitPoints()
        {
            image.fillAmount = (float)destructible.GetHitPoints() / (float)destructible.GetMaxHitPoints();
        }
    }
}
