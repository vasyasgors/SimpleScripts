using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleScripts
{
    public class KeyboardEvent : MonoBehaviour
    {
        [SerializeField] private KeyState state;
        [SerializeField] private KeyCode key;

        public UnityEvent OnEvent;

        void Update()
        {
            if (state == KeyState.Down && Input.GetKeyDown(key))
                if (OnEvent != null) OnEvent.Invoke();

            if (state == KeyState.Up && Input.GetKeyUp(key))
                if (OnEvent != null) OnEvent.Invoke();

            if (state == KeyState.Pressed && Input.GetKey(key))
                if (OnEvent != null) OnEvent.Invoke();
        }


    }
}



