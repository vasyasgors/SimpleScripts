using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleScripts
{
	public class Trigger : Interactive 
	{
	
		[SerializeField] private UnityEvent OnEnter;
		[SerializeField] private UnityEvent OnExit;
		[SerializeField] private UnityEvent OnStay;

		void OnTriggerEnter(Collider col)
		{
			if (col.tag != InteractTag) return;
			
			OnEnter.Invoke ();
		}

		void OnTriggerStay(Collider col)
		{
			if (col.tag != InteractTag) return;

			OnStay.Invoke();
		}

		void OnTriggerExit(Collider col)
		{
			if (col.tag != InteractTag) return;

			OnExit.Invoke ();
		}
	}

}