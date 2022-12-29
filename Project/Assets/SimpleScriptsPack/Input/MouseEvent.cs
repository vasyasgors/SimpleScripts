using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleScripts
{
    public class MouseEvent: MonoBehaviour
    {
   
        [SerializeField] private KeyState state;
        [SerializeField] private int keyNumber;

        public UnityEvent OnEvent;

        void Update()
        {
            if (state == KeyState.Down && Input.GetMouseButtonDown(keyNumber))
                if (OnEvent != null) OnEvent.Invoke();

            if (state == KeyState.Up && Input.GetMouseButtonUp(keyNumber))
                if (OnEvent != null) OnEvent.Invoke();

            if (state == KeyState.Pressed && Input.GetMouseButton(keyNumber))
                if (OnEvent != null) OnEvent.Invoke();
        }
    }
}



