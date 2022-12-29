using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleScripts
{
	public class KeyTrigger : MonoBehaviour
	{
		public KeyCode Key;
		public UnityEvent OnPress;

		private bool IsStay;

		void OnTriggerEnter(Collider col)
		{
			if (col.tag != "Player")
				return;
			IsStay = true;
		}

		void OnTriggerExit(Collider col)
		{
			if (col.tag != "Player")
				return;

			IsStay = false;
		}

		void Update()
		{
			if(IsStay == false) return;

			if(Input.GetKeyDown(Key))
			{
				OnPress.Invoke();
			}
		}
	}
}
