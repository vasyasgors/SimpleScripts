using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleScripts
{
    public class UIHealthText : MonoBehaviour
    {
        [SerializeField] private Destructible destructible;
        [SerializeField] private Text text;

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
            text.text = destructible.GetHitPoints().ToString();
        }
    }
}

