using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleScripts
{
	public class ActiveSwitch : MonoBehaviour
    {
        public UnityEvent OnActive;
        public UnityEvent OnDeactive;

        public void Switch()
        {
            gameObject.SetActive(!gameObject.activeSelf);

            if (gameObject.activeSelf == true)
            {
                if (OnActive != null) OnActive.Invoke();
            }
            else
            {
                if (OnDeactive != null) OnDeactive.Invoke();
            }
           
        }


    }
}
